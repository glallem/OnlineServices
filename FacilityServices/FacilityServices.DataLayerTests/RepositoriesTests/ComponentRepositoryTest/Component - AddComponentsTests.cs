﻿using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.ComponentRepositoryTest
{
    [TestClass]
    public class AddComponentsTests
    {
        [TestMethod]
        public void AddComponent_ShouldInsertInDb_WhenValidComponentIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                // Arrange
                IComponentRepository componentRepository = new ComponentRepository(memoryCtx);
                IRoomRepository roomRepository = new RoomRepository(memoryCtx);
                IFloorRepository floorRepository = new FloorRepository(memoryCtx);
                IComponentTypeRepository componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                var componentRepository = new ComponentRepository(memoryCtx);

                // Act
                componentRepository.Add(component);
                memoryCtx.SaveChanges();

                // Assert
                Assert.AreEqual(1, componentRepository.GetAll().Count());
                var componentToAssert = componentRepository.GetByID(1);
                Assert.AreEqual(1, componentToAssert.Id);
                Assert.AreEqual(1, componentToAssert.Room.Id);
                Assert.AreEqual("WC Men", componentToAssert.Room.Name.English);
            }
        }

        [TestMethod]
        public void AddComponent_ShouldThrowException_WhenNullIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                // Arrange
                ComponentTO component = null;
                var componentRepository = new ComponentRepository(memoryCtx);

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => componentRepository.Add(component));
            }
        }
    }
}
