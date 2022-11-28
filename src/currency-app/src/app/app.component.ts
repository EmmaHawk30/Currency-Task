import { Component } from '@angular/core';
import { ConversionService } from './services/conversion.service'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Currency Converter';

  constructor(private conversionservice : ConversionService) { }
}
