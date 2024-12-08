import { TestBed } from '@angular/core/testing';

import { VacancyExamService } from './vacancy-exam.service';

describe('VacancyExamService', () => {
  let service: VacancyExamService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VacancyExamService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
