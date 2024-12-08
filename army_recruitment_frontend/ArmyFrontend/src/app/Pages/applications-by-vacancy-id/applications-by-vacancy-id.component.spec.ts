import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationsByVacancyIdComponent } from './applications-by-vacancy-id.component';

describe('ApplicationsByVacancyIdComponent', () => {
  let component: ApplicationsByVacancyIdComponent;
  let fixture: ComponentFixture<ApplicationsByVacancyIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicationsByVacancyIdComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApplicationsByVacancyIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
