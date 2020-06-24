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

        public IList<ReportType> Reports { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HerokuTestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(DateTime? createdAt)
        {
            if (createdAt.HasValue)
            {
                Reports = (from contr in _context.Contracts
                           join usr in _context.Users
                           on contr.UserId equals usr.Id
                           select new ReportType { Name = usr.Name, SecondName = usr.SecondName, ThirdName = usr.ThirdName, Balance = contr.Balance }).ToList();
                
                return;
            }

            Contracts = (from contr in _context.Contracts
                         select new Contracts{ ContractId = contr.ContractId, Balance = contr.Balance }).ToList();
        }

        public class ReportType
        {
            public string Name { get; set; }

            public string SecondName { get; set; }

            public string ThirdName { get; set; }

            public long Balance { get; set; }

        }

    }
}
