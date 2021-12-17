using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet]
        public IActionResult App()
        {
            // Creating a new loan object instance
            LoanInfo loan = new();

            // Set the loan info
            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.InterestRate = 3.5m;
            loan.LoanAmount = 15000m;
            loan.TermAmount = 60;

            // Returning to the view
            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(LoanInfo loanInfo)
        {
            // Calculate the loan


            return View(loanInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
