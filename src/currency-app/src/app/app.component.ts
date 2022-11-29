import { Component } from '@angular/core';
import { CurrencyApiService } from './services/currencyApi.service'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Currency Converter';

  constructor(private currencyApiService : CurrencyApiService) { }
}
