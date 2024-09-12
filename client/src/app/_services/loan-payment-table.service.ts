import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanData } from '../_models/loan-data'; // Assuming LoanData is defined in this path
import { LoanPaymentTable } from '../_models/loan-payment-table'; // Assuming LoanPaymentTable is defined in this path


@Injectable({
  providedIn: 'root'
})
export class LoanPaymentTableService {
  http = inject(HttpClient);
  private readonly baseUrl = "http://localhost:5000/api";
  private readonly url = `${this.baseUrl}/loanpayment/calculate`;

  getLoanPaymentTable(loanData: LoanData): Observable<LoanPaymentTable> {
    // Prepare query parameters
    let params = new HttpParams()
      .set('loanAmount', loanData.loanAmount.toString())
      .set('interestRate', loanData.interestRate.toString())
      .set('durationMonths', loanData.durationMonths.toString());

    // Send GET request with query parameters
    return this.http.get<LoanPaymentTable>("http://localhost:5000/api/loanpayment/calculate", { params })
  }
}
