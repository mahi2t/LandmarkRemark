import { TestBed } from '@angular/core/testing';

import { LandmarkFormService } from './landmark-form.service';

describe('LandmarkFormService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LandmarkFormService = TestBed.get(LandmarkFormService);
    expect(service).toBeTruthy();
  });
});
