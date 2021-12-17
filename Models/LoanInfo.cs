namespace Project_EZLoan.Models
{
    public class LoanInfo
    {
        // Loan Infomation
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermAmount { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }
    }
}
