import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacancyExamComponent } from './vacancy-exam.component';

describe('VacancyExamComponent', () => {
  let component: VacancyExamComponent;
  let fixture: ComponentFixture<VacancyExamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VacancyExamComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VacancyExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
