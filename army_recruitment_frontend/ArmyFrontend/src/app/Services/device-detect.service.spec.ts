import { TestBed } from '@angular/core/testing';

import { DeviceDetectService } from './device-detect.service';

describe('DeviceDetectService', () => {
  let service: DeviceDetectService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeviceDetectService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
