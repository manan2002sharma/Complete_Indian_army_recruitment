import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacancyExamResultComponent } from './vacancy-exam-result.component';

describe('VacancyExamResultComponent', () => {
  let component: VacancyExamResultComponent;
  let fixture: ComponentFixture<VacancyExamResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VacancyExamResultComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VacancyExamResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
