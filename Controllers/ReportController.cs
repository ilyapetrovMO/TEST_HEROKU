using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HerokuTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerokuTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public HerokuTestContext Context { get; }

        public ReportController(HerokuTestContext context)
        {
            Context = context;
        }
        
        [HttpGet]
        public ActionResult<long> GetBalance([Required, FromQuery] int contractId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Context.Contracts.FirstOrDefault(c => c.ContractId == contractId);

            if (result != null)
            {
                return Ok(result.Balance);
            }

            return NotFound();
        }
    }
}
