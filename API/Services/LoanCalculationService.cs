using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Services
{
    public class LoanCalculationService
    {
        public OdemePlani CalculateLoanPaymentSchedule(double krediTutari, double faiz, int vade)
        {
            // Create a LoanPaymentTable object
            var odemePlani = new OdemePlani();
            odemePlani.OdemeSayisi = vade;
            faiz = faiz/100;
            //A=P*(A GIVEN P MULTIPLIER)
            //values at the end of period 0
            double taksit = krediTutari * (faiz*Math.Pow(1+faiz,vade))/(Math.Pow(1+faiz,vade)-1);
            double faizOdemesi = krediTutari * faiz;
            double anaparaOdemesi = taksit - faizOdemesi;
            double kalanTutar = (krediTutari - anaparaOdemesi);

            for(int i = 1; i<= vade; i++){
                odemePlani.Satirlar.Add(new OdemeSatiri{ 
                    Faiz = faizOdemesi, 
                    Taksit = taksit, 
                    TaksitNo = i, 
                    Anapara = anaparaOdemesi, 
                    KalanTutar = kalanTutar});

                faizOdemesi = kalanTutar * faiz;
                anaparaOdemesi = taksit - faizOdemesi;
                kalanTutar = (kalanTutar - anaparaOdemesi);
            }

            return odemePlani;
        }
    }
}
/*
        public LoanPaymentTable CalculateLoanPaymentSchedule(double loanAmount, double interestRate, int durationMonths)
        {
            // Create a LoanPaymentTable object
            var paymentTable = new LoanPaymentTable();
            paymentTable.TotalNumPayments = durationMonths;
            interestRate = interestRate/100;
            //A=P*(A GIVEN P MULTIPLIER)
            //values at the end of period 0
            double monthlyInstallment = loanAmount * (interestRate*Math.Pow(1+interestRate,durationMonths))/(Math.Pow(1+interestRate,durationMonths)-1);
            double interestPayment = loanAmount * interestRate;
            double principalPayment = monthlyInstallment - interestPayment;
            double remainingBalance = loanAmount - monthlyInstallment;

            for(int i = 1; i<= durationMonths; i++){
                paymentTable.Rows.Add(new LoanPaymentRow{ 
                    InterestPayment = interestPayment, 
                    MonthlyInstallment = monthlyInstallment, 
                    PaymentNumber = i, 
                    PrincipalPayment = principalPayment, 
                    RemainingBalance = remainingBalance});

                monthlyInstallment = remainingBalance * (interestRate*Math.Pow(1+interestRate,durationMonths-i))/(Math.Pow(1+interestRate,durationMonths-i)-1);

                interestPayment = remainingBalance * interestRate;
                principalPayment = monthlyInstallment - interestPayment;
                remainingBalance = remainingBalance - monthlyInstallment;
            }

            return paymentTable;
        }
    }

*/

