namespace Project_EZLoan.Models
{
    public class LoanPayment
    {
        public int Month { get; set; }
        public decimal CalculatePayment { get; set; }
        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal Ballance { get; set; }
    }
}
