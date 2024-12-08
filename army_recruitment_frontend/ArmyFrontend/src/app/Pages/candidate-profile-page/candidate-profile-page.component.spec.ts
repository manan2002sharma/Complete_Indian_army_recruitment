import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateProfilePageComponent } from './candidate-profile-page.component';

describe('CandidateProfilePageComponent', () => {
  let component: CandidateProfilePageComponent;
  let fixture: ComponentFixture<CandidateProfilePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandidateProfilePageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CandidateProfilePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
