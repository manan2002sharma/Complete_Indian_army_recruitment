import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllApplicationPageComponent } from './all-application-page.component';

describe('AllApplicationPageComponent', () => {
  let component: AllApplicationPageComponent;
  let fixture: ComponentFixture<AllApplicationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllApplicationPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AllApplicationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
