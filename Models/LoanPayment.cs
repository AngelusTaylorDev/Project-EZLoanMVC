namespace Project_EZLoan.Models
{
    public class LoanPayment
    {
        // Loan Payment Info
        public int Month { get; set; }
        public decimal CalculatedPayment { get; set; }
        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal Ballance { get; set; }
    }
}
