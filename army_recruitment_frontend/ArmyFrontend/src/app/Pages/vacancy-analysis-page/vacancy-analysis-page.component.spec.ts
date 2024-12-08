import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacancyAnalysisPageComponent } from './vacancy-analysis-page.component';

describe('VacancyAnalysisPageComponent', () => {
  let component: VacancyAnalysisPageComponent;
  let fixture: ComponentFixture<VacancyAnalysisPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VacancyAnalysisPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VacancyAnalysisPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
