import { Injectable } from '@angular/core';
import { Conversion } from '../interfaces/conversion.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CurrencyApiService {

  constructor(private http: HttpClient) { }

  public convertAmount = (route: string, conversion: Conversion) => {
    return this.http.post<Conversion>(route, conversion, this.generateHeaders());
  }

  public generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}

