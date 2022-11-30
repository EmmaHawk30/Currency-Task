import { Component } from '@angular/core';
import { Conversion } from './interfaces/conversion.model';
import { CurrencyApiService } from './services/currencyApi.service'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Currency Converter';

  conversion: Conversion = {
    convertFrom: "GBP",
    convertTo: "GBP",
    amount: 1 
  };

  constructor(private currencyApiService : CurrencyApiService) { }

  convertCurrency() {
    this.currencyApiService.convert(this.conversion).subscribe((response: any) => {
      this.conversion = response;
      console.log(response);
    });
  }
}
