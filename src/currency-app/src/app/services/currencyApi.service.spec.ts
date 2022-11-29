import { TestBed } from '@angular/core/testing';

import { CurrencyApiService } from './currencyApi.service';

describe('ConversionService', () => {
  let service: CurrencyApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
