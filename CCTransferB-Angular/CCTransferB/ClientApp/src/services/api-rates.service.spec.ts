import { TestBed } from '@angular/core/testing';

import { ApiRate } from './api-rates.service';

describe('ApiRateService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));

    it('should be created', () => {
        const service: ApiRate = TestBed.get(ApiRate);
        expect(service).toBeTruthy();
    });
});
