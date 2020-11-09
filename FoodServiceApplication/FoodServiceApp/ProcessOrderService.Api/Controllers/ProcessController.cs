using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessOrderService.Api.Application.Interfaces;
using ProcessOrderService.Api.Domain.Models;

namespace ProcessOrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        // GET api/transfer
        [HttpGet]
        public ActionResult<IEnumerable<ProcessOrderLog>> Get()
        {
            return Ok(_processService.GetOrderLogs());
        }
    }
}
