public class LoanPaymentTable
{   
    public int Id { get; set; }
    public int TotalNumPayments { get; set; }
    public List<LoanPaymentRow> Rows { get; set; }
    public LoanPaymentTable()
    {
        Rows = new List<LoanPaymentRow>();
    }
}
