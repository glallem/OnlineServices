﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceServices.BusinessLayer.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace OS.WebAPI.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ASAttendeeController : ControllerBase
    {
        private readonly ILogger<ASAttendeeController> _logger;
        private readonly IASAttendeeRole iASAttendeeRole;

        public ASAttendeeController(ILogger<ASAttendeeController> logger, IASAttendeeRole iASAttendeeRole)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.iASAttendeeRole = iASAttendeeRole ?? throw new ArgumentNullException(nameof(iASAttendeeRole));
        }

        [HttpGet]
        public IEnumerable<SessionTO> GetTodaySessions()
        {
            return iASAttendeeRole.GetTodaySessions();
        }

        [HttpGet]
        public bool SetPresence(int sessionId, int attendeeId)
        {
            return iASAttendeeRole.SetPresence(sessionId, attendeeId);
        }
    }
}
