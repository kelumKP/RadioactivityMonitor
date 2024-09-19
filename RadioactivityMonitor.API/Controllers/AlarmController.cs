using Microsoft.AspNetCore.Mvc;
using RadioactivityMonitor.Application.DTOs;
using RadioactivityMonitor.Application.Interfaces;

namespace RadioactivityMonitor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        [HttpGet("check")]
        public ActionResult<AlarmDto> CheckAlarm()
        {
            var alarmStatus = _alarmService.CheckAlarm();
            return Ok(alarmStatus);
        }
    }
}
