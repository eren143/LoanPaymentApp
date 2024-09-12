import { Component, Input, inject, SimpleChanges, OnChanges } from '@angular/core';
import { AraOdemeliFormBilgisi } from '../_models/ara-odemeli-form-bilgisi';
import { AraOdemePlani } from '../_models/ara-odeme-plani';
import { AraOdemeService } from '../_services/ara-odeme.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-odeme-plani',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './odeme-plani.component.html',
  styleUrls: ['./odeme-plani.component.css']
})
export class OdemePlaniComponent implements OnChanges {
  @Input() formBilgisi: AraOdemeliFormBilgisi | null = null;
  odemePlani: AraOdemePlani | null = null;
  inputTableId: number | null = null;

  araOdemeServisi = inject(AraOdemeService);

  ngOnChanges(changes: SimpleChanges) {
    if (changes['formBilgisi'] && this.formBilgisi) {
      console.log('OdemePlaniComponent received formBilgisi:', this.formBilgisi);
      this.createLoanPaymentTable(this.formBilgisi);
    }
  }

  createLoanPaymentTable(formBilgisi: AraOdemeliFormBilgisi) {
    if (formBilgisi.araOdemeSikliği == 0 ||
      formBilgisi.araOdemeTutari == 0 ||
      formBilgisi.ilkAraOdemeTaksitNo == 0
    ) {
      this.araOdemeServisi.klasikOdemePlaniAl(formBilgisi).subscribe({
        next: response => {
          console.log('Received payment plan from API:', response);
          this.odemePlani = this.transformResponse(response);
        },
        error: error => {
          console.error('Error occurred while fetching payment plan:', error);
        }
      });

    } else {
      this.araOdemeServisi.getLoanPaymentTable(formBilgisi).subscribe({
        next: response => {
          console.log('Received payment plan from API:', response);
          this.odemePlani = this.transformResponse(response);
        },
        error: error => {
          console.error('Error occurred while fetching payment plan:', error);
        }
      });
    }
  }

  // Transform the response to extract the array from the nested structure
  private transformResponse(response: any): AraOdemePlani {
    return {
      ...response,
      satirlar: response.satirlar.$values
    };
  }

  fetchTableById() {
    if (this.inputTableId) {
      this.araOdemeServisi.getTableById(this.inputTableId).subscribe({
        next: response => {
          console.log('Received payment plan for table ID:', response);
          this.odemePlani = this.transformResponse(response);
        },
        error: error => {
          console.error('Error occurred while fetching payment plan by ID:', error);
        }
      });
    }
}
}