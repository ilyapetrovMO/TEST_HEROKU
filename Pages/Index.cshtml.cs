using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerokuTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HerokuTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HerokuTestContext _context;

        public IList<Contracts> Contracts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HerokuTestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet([FromQuery] DateTime? createdAt)
        {
            Contracts = (from contr in _context.Contracts
                         select new Contracts{ ContractId = contr.ContractId, Balance = contr.Balance }).ToList();
        }


    }
}
