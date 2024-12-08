import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacancyOverlayComponent } from './vacancy-overlay.component';

describe('VacancyOverlayComponent', () => {
  let component: VacancyOverlayComponent;
  let fixture: ComponentFixture<VacancyOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VacancyOverlayComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VacancyOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
