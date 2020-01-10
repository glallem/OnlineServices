﻿using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.TranslationServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("ComponentTypes")]
    public class ComponentTypeEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }
        public bool Archived { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public string NameDutch { get; set; }
        // public List<IssueEF> Issues { get; set; }
    }
}
