import { Component, Input, inject, SimpleChanges, OnChanges } from '@angular/core';
import { AraOdemeliFormBilgisi } from '../_models/ara-odemeli-form-bilgisi';
import { AraOdemePlani } from '../_models/ara-odeme-plani';
import { AraOdemeService } from '../_services/ara-odeme.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ara-odeme-plani',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ara-odeme-plani.component.html',
  styleUrls: ['./ara-odeme-plani.component.css']
})
export class AraOdemePlaniComponent implements OnChanges {
  @Input() formBilgisi: AraOdemeliFormBilgisi | null = null;
  isValid: boolean = false;
  odemePlani: AraOdemePlani | null = null;
  araOdemeServisi = inject(AraOdemeService);

  ngOnChanges(changes: SimpleChanges) {
    if (changes['formBilgisi'] && this.formBilgisi) {
      console.log('AraOdemePlaniComponent received formBilgisi:', this.formBilgisi);
      this.createLoanPaymentTable(this.formBilgisi);
    }
  }

  createLoanPaymentTable(formBilgisi: AraOdemeliFormBilgisi) {
    this.araOdemeServisi.getLoanPaymentTable(formBilgisi).subscribe({
      next: response => {
        console.log('Received payment plan from API:', response);
        this.odemePlani = response;
        this.isValid = true;
      },
      error: error => {
        console.error('Error occurred while fetching payment plan:', error);
        this.isValid = false;
      }
    });
  }
}
