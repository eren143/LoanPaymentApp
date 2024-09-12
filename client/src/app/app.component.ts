import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoanFormComponent } from './loan-form/loan-form.component';
import { LoanPaymentTableComponent } from './loan-payment-table/loan-payment-table.component';
import { LoanData } from './_models/loan-data';
import { OdemeFormuComponent } from "./odeme-formu/odeme-formu.component";
import { AraOdemeliFormBilgisi } from './_models/ara-odemeli-form-bilgisi';
import { AraOdemePlaniComponent } from "./ara-odeme-plani/ara-odeme-plani.component";
import { OdemePlaniComponent } from './odeme-plani/odeme-plani.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LoanFormComponent, LoanPaymentTableComponent, OdemeFormuComponent, OdemePlaniComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  formBilgisi : AraOdemeliFormBilgisi | null = null;
  
  setAraOdemeliForm(formBilgisi: AraOdemeliFormBilgisi) {
    this.formBilgisi = formBilgisi;
    console.log('Parent received form data:', this.formBilgisi);
  }

}
