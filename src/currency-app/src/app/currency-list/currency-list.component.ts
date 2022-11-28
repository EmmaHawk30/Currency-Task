import { Component, OnInit } from '@angular/core';
import { CURRENCIES } from '../currencies';
import { Currency } from '../currency';

@Component({
  selector: 'app-currency-list',
  templateUrl: './currency-list.component.html',
  styleUrls: ['./currency-list.component.css']
})

export class CurrencyListComponent implements OnInit {

  currencies = CURRENCIES;
  selectedCurrency?: Currency;

  constructor() {}

  ngOnInit(): void {
  }

  onSelect(currency: Currency): void {
    this.selectedCurrency = currency;
  }
}

