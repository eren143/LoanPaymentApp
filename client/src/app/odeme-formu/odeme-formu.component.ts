import { Component,inject, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { LoanFormValidatorsService } from '../_services/loan-form-validators.service';
import { AraOdemeliFormBilgisi } from '../_models/ara-odemeli-form-bilgisi';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-odeme-formu',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './odeme-formu.component.html',
  styleUrl: './odeme-formu.component.css'
})
export class OdemeFormuComponent {
  formValidators = inject(LoanFormValidatorsService)
  @Output() formBilgisiYukle = new EventEmitter<AraOdemeliFormBilgisi>();
  
  submittedFormValue : AraOdemeliFormBilgisi | null = null;
  OdemeFormu = new FormGroup({
    krediTutari: new FormControl('',[Validators.required, this.formValidators.positiveNumberValidator]),
    vade: new FormControl('',[Validators.required, this.formValidators.positiveNumberValidator]),
    faiz: new FormControl('',[Validators.required,this.formValidators.positiveNumberValidator]),
    araOdemeTutari: new FormControl(),
    araOdemeSikliği: new FormControl(),
    ilkAraOdemeTaksitNo: new FormControl(),
  });
  
  onSubmit() {
    if (this.OdemeFormu.valid) {
      const formBilgisi = this.OdemeFormu.value;
      if(formBilgisi.araOdemeTutari == null){
      }
      const FormBilgisi : AraOdemeliFormBilgisi = {
        krediTutari: Number(formBilgisi.krediTutari),
        vade: Number(formBilgisi.vade),
        faiz: Number(formBilgisi.faiz),
        araOdemeTutari: Number(formBilgisi.araOdemeTutari),
        araOdemeSikliği: Number(formBilgisi.araOdemeSikliği),
        ilkAraOdemeTaksitNo: Number(formBilgisi.ilkAraOdemeTaksitNo)
      };
      this.submittedFormValue = FormBilgisi;
      this.formBilgisiYukle.emit(FormBilgisi);
    }
  }
}