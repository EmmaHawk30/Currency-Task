import { Component } from '@angular/core';
import { CurrencyApiService } from './services/currencyApi.service'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Currency Converter';

  conversion = 

  convertFrom = 'GBP';
  convertTo = 'GBP';
  amount: string = "1";

  constructor(private currencyApiService : CurrencyApiService) { }

  convert() {
    this.currencyApiService.convertAmount(this.conversion);
  }
}
