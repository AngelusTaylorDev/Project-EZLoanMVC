using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_EZLoan.Helper;
using Project_EZLoan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_EZLoan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TheCode()
        {
            return View();
        }

        public IActionResult App()
        {
            // Creating a new loan object instance
            LoanInfo loanInfo = new();

            // Set the loan info
            loanInfo.Payment = 0.0m;
            loanInfo.TotalInterest = 0.0m;
            loanInfo.TotalCost = 0.0m;
            loanInfo.InterestRate = 3.5m;
            loanInfo.LoanAmount = 15000m;
            loanInfo.TermAmount = 60;

            // Returning to the view
            return View(loanInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(LoanInfo loanInfo)
        {
            // Calculate the loan and get the payments
            var loanBusinessLogic = new LoanBusinessLogic();

            LoanInfo newLoan = loanBusinessLogic.GetPayments(loanInfo);

            return View(newLoan);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
