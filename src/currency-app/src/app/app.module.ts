import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyListComponent } from './currency-list/currency-list.component';
import { ConversionService } from './services/conversion.service';

@NgModule({
  declarations: [
    AppComponent,
    CurrencyListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ConversionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
