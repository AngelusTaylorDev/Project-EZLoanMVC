using Project_EZLoan.Models;
using System;

namespace Project_EZLoan.Helper
{
	public class LoanBusinessLogic
	{
		public LoanInfo GetPayments(LoanInfo loanInfo)
		{
			// Calculate monthly payment 
			loanInfo.Payment = CalcPayment(loanInfo.LoanAmount, loanInfo.InterestRate, loanInfo.TermAmount);

			// Create a loop and loop from 1 to term.length

			// Calculate the payment schedule

			// Push Payments into the loan

			// Return the loan


			return loanInfo;
		}

		// Calculate monthly payment 
		private decimal CalcPayment(decimal loanAmount, decimal interestRate, int termAmount)
		{
			// Run the monthlyInterestRate Method
			var monthlyInterestRate = CalcMonthlyInterestRate(interestRate);

			// convert the Payment ammount to a double (Needed cas C# only works with doubles not decimals)
			var monthlyInterestRateD = Convert.ToDouble(monthlyInterestRate);
			var loanAmountD = Convert.ToDouble(loanAmount);

			// Calclating the Payment algo
			var paymentD = (termAmount * monthlyInterestRateD) / (1-Math.Pow(1 + monthlyInterestRateD, - termAmount));

			return Convert.ToDecimal(paymentD);
		}

		// Calculate monthly Interest Rate 
		private decimal CalcMonthlyInterestRate(decimal interestRate)
		{
			return interestRate / 1200;
		}
	}
}
