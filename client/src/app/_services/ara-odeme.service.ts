import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AraOdemeliFormBilgisi } from '../_models/ara-odemeli-form-bilgisi';
import { Observable } from 'rxjs';
import { AraOdemePlani } from '../_models/ara-odeme-plani';
import { HttpParams } from '@angular/common/http';
import { LoanPaymentTable } from '../_models/loan-payment-table';
@Injectable({
  providedIn: 'root'
})
export class AraOdemeService {
  http = inject(HttpClient);
  private readonly baseUrl = "http://localhost:5000/api";
  private readonly url = `${this.baseUrl}/AraOdeme/calculate`;

  getLoanPaymentTable(formBilgisi: AraOdemeliFormBilgisi): Observable<AraOdemePlani> {
    // Prepare query parameters
    let params = new HttpParams()
      .set('krediTutari', formBilgisi.krediTutari.toString())
      .set('vade', formBilgisi.vade.toString())
      .set('faiz', formBilgisi.faiz.toString())
      .set('ilkAraOdemeTaksitNo', formBilgisi.ilkAraOdemeTaksitNo.toString())
      .set('araOdemeSikliği', formBilgisi.araOdemeSikliği.toString())
      .set('araOdemeTutari', formBilgisi.araOdemeTutari.toString());

    // Send GET request with query parameters
    return this.http.get<AraOdemePlani>(this.url, { params })
  }

  klasikOdemePlaniAl(formBilgisi: AraOdemeliFormBilgisi): Observable<AraOdemePlani> {
    // Prepare query parameters
    let params = new HttpParams()
      .set('krediTutari', formBilgisi.krediTutari.toString())
      .set('faiz', formBilgisi.faiz.toString())
      .set('vade', formBilgisi.vade.toString());

    // Send GET request with query parameters
    return this.http.get<AraOdemePlani>("http://localhost:5000/api/loanpayment/calculate", { params })
  }
}
