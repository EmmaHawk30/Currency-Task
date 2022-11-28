import { Injectable } from '@angular/core';
import { Conversion } from '../interfaces/conversion.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ConversionService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public convertAmount = (route: string, conversion: Conversion) => {
    return this.http.post<Conversion>(this.createCompleteRoute(route, this.envUrl.urlAddress), conversion, this.generateHeaders());
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}

