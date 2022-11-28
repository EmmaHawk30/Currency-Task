import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentUrlService {
  urlAddress: string = environment.urlAddress;

  constructor() { }
}
