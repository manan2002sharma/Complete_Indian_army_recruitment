import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVacancyPageComponent } from './add-vacancy-page.component';

describe('AddVacancyPageComponent', () => {
  let component: AddVacancyPageComponent;
  let fixture: ComponentFixture<AddVacancyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddVacancyPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddVacancyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
