/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DataPassService } from './data-pass.service';

describe('Service: DataPass', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DataPassService]
    });
  });

  it('should ...', inject([DataPassService], (service: DataPassService) => {
    expect(service).toBeTruthy();
  }));
});
