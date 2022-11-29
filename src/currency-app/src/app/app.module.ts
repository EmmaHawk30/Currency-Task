import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyListComponent } from './currency-list/currency-list.component';
import { CurrencyApiService } from './services/currencyApi.service';

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
  providers: [CurrencyApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
