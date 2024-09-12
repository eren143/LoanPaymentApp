import { Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class LoanFormValidatorsService {

  positiveNumberValidator() : ValidatorFn {
    //input: control
    //return validation errors or null

    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
  
      // Check if the value is a number
      if (isNaN(value)) {
        return { notNumber: true };
      }
      
      // Convert value to a number and check if it's positive
      const numberValue = Number(value);
      if (numberValue <= 0) {
        return { notPositive: true };
      }
  
      return null; // Validation passed
    };
  }
}
