import { Injectable } from '@angular/core';
import { Conversion } from '../interfaces/conversion.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class CurrencyApiService {

  res: any;

  constructor(private http: HttpClient) { }

  public convert(conversion: Conversion): Observable<any> {
    let baseUrl = "http://localhost:49153/Currency.API/api/convert-currency"
    return this.http.post(`${baseUrl}/?convertFrom=${conversion.convertFrom}&convertTo=${conversion.convertTo}&amount=${conversion.amount}`, conversion, {
      headers: new HttpHeaders({
     "Content-Type": "application/json"
          })
      });
  }
}
