import { Injectable } from '@angular/core';
import { Conversion } from '../interfaces/conversion.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrencyApiService {

  constructor(private http: HttpClient) { }

  public convert(conversion: Conversion): Observable<any> {
    let baseUrl = "https://localhost/Currency.API/api/convert-currency"
    return this.http.post(`${baseUrl}/?convertFrom=${conversion.convertFrom}&convertTo=${conversion.convertTo}&amount=${conversion.amount}`, conversion);
  }
}
