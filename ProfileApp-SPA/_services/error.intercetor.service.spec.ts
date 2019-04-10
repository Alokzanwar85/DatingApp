/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { Error.intercetorService } from './error.intercetor.service';

describe('Service: Error.intercetor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Error.intercetorService]
    });
  });

  it('should ...', inject([Error.intercetorService], (service: Error.intercetorService) => {
    expect(service).toBeTruthy();
  }));
});
