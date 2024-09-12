using System;

namespace API.Entities;

public class LoanInformation
{
    public double LoanAmount { get; set; }
    public int DurationMonths { get; set; }
    public double InterestRate { get; set; }
    
}
