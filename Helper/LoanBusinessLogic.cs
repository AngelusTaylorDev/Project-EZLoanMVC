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
			var ballance = loanInfo.LoanAmount;
			var totalInterest = 0.0m;
			var monthlyInterestRate = CalcMonthlyInterest(loanInfo.InterestRate);
			var monthlyInterest = 0.0m;
			var monthlyPrincipal = 0.0m;

			// Looping over each month untel term end of the loan (Calculate the payment schedule)
			for (int month = 1; month <= loanInfo.TermAmount; month++)
            {
				// calculate monthly Interest 
				monthlyInterest = calcMonthlyInterestRate(ballance, monthlyInterestRate);

				// calculate Total Intrest 
				totalInterest += monthlyInterest;

				// calculate monthly Principal
				monthlyPrincipal = loanInfo.Payment - monthlyInterest;

				// calculate ballance
				ballance -= monthlyPrincipal;

				// Make a new instance of loan payments
				LoanInfo LoanPayments = new();

				// Stetting the loan payments properties
				LoanPayment loanPayment = new();
				loanPayment.Month = month;
				loanPayment.CalculatedPayment = loanInfo.Payment;
				loanPayment.MonthlyPrincipal = monthlyPrincipal;
				loanPayment.MonthlyInterestRate = monthlyInterest;
				loanPayment.TotalInterest = totalInterest;
				loanPayment.Ballance = ballance;

				// Push the object into the loan model
				loanInfo.LoanPayments.Add(loanPayment);
			}

			// Calculate total intrest at the end of the term
			loanInfo.TotalInterest = totalInterest;

			// Calculate total intrest at the end of the term
			loanInfo.TotalCost = loanInfo.LoanAmount + totalInterest;

			// Retrun the loan to the view (Push Payments into the loan)
			return loanInfo;
		}

		// Calculate monthly payment 
		private decimal CalcPayment(decimal loanAmount, decimal interestRate, int termAmount)
		{
			// Run the monthlyInterestRate Method
			var monthlyInterestRate = CalcMonthlyInterest(interestRate);

			// convert the Payment ammount to a double (Needed cas C# only works with doubles not decimals)
			var monthlyInterestRateD = Convert.ToDouble(monthlyInterestRate);
			var loanAmountD = Convert.ToDouble(loanAmount);

            // Calclating the Payment algo
            var paymentD = (loanAmountD * monthlyInterestRateD) / (1-Math.Pow(1 + monthlyInterestRateD, -termAmount));

            return Convert.ToDecimal(paymentD);
		}

		// Calculate monthly Interest 
		private decimal CalcMonthlyInterest(decimal interestRate)
		{
			return interestRate / 1200;
		}

		// Calculate the monthly intrest rate
		private decimal calcMonthlyInterestRate(decimal ballance, decimal monthlyInterest)
        {
			return ballance * monthlyInterest;
        }
	}
}
