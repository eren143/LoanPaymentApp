import { Component, inject } from '@angular/core';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Input } from '@angular/core';
import { LoanData } from '../_models/loan-data';
import { LoanFormComponent } from "../loan-form/loan-form.component";
import { LoanPaymentTableService } from '../_services/loan-payment-table.service';
import { LoanPaymentTable } from '../_models/loan-payment-table';
import { SimpleChanges } from '@angular/core';
@Component({
  selector: 'app-loan-payment-table',
  standalone: true,
  imports: [LoanFormComponent, CommonModule],
  templateUrl: './loan-payment-table.component.html',
  styleUrl: './loan-payment-table.component.css'
})
export class LoanPaymentTableComponent {
  @Input() loanData: LoanData | null = null;
  isTableAvailable: boolean = false;
  loanPaymentTable: LoanPaymentTable | null = null;
  loanPaymentTableService = inject(LoanPaymentTableService);
  
  ngOnChanges(changes: SimpleChanges) {
    if (changes['loanData'] && this.loanData) {
      this.createLoanPaymentTable(this.loanData);
    }
  }

  createLoanPaymentTable(loanData: LoanData) {
    this.loanPaymentTableService.getLoanPaymentTable(loanData).subscribe({
      next: response => {
        this.loanPaymentTable = response;
        this.isTableAvailable = true;
        console.log('Calculation result:', response);
      },
      error: error => {
        // Handle any errors here
        console.error('Error occurred:', error);
      }
    });
  }
}
  