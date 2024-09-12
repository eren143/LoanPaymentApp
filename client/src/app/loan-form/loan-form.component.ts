import { Component, inject, Output, EventEmitter } from '@angular/core';
import { ReactiveFormsModule, Validators, FormGroup, FormControl} from '@angular/forms';
import { NgIf } from '@angular/common';
import { LoanData } from '../_models/loan-data';
import { LoanFormValidatorsService } from '../_services/loan-form-validators.service';

@Component({
  selector: 'app-loan-form',
  standalone: true,
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './loan-form.component.html',
  styleUrl: './loan-form.component.css'
})

export class LoanFormComponent {
  formValidators = inject(LoanFormValidatorsService)
  @Output() loanDataSubmit = new EventEmitter<LoanData>();

  loanForm = new FormGroup({
    loanAmount: new FormControl('',[Validators.required, this.formValidators.positiveNumberValidator]),
    durationMonths: new FormControl('',[Validators.required, this.formValidators.positiveNumberValidator]),
    interestRate: new FormControl('',[Validators.required,this.formValidators.positiveNumberValidator])
  });
  
  onSubmit() {
    if (this.loanForm.valid) {
      // Convert form control values to numbers
      const formValue = this.loanForm.value;
      const loanData : LoanData = {
        loanAmount: Number(formValue.loanAmount),
        durationMonths: Number(formValue.durationMonths),
        interestRate: Number(formValue.interestRate)
      };

      this.loanDataSubmit.emit(loanData);
    } 
  }
}
