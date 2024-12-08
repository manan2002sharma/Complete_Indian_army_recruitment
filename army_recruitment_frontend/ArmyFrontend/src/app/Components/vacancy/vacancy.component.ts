import { Component, Input } from '@angular/core';
import { Vacancy } from '../../Data/Vacancy';
import { CommonModule } from '@angular/common';
import { VacancyOverlayComponent } from '../vacancy-overlay/vacancy-overlay.component';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { VacancyService } from '../../Services/vacancy.service';
@Component({
  selector: 'app-vacancy',
  standalone: true, 
  imports: [CommonModule,VacancyOverlayComponent,FormsModule],
  templateUrl: './vacancy.component.html',
  styleUrl: './vacancy.component.css'
})
export class VacancyComponent {
  @Input() vacancy: Vacancy | null = null;
  showOverlay = false;
  role: string | null = null;  

  constructor(
    private vacancyService: VacancyService, // Inject the vacancy service
    private router: Router  // Inject the router to navigate to See Applications page
  ) {}

  ngOnInit(): void {
    this.role = localStorage.getItem('Userrole'); // Get the role from localStorage
  }

  openApplyOverlay(): void {
    this.showOverlay = true;
  }

  closeApplyOverlay(event: boolean): void {
    this.showOverlay = event;
  }

  // Handle the removal of a vacancy
  removeVacancy(): void {
    if (this.vacancy?.vacancyId) {
      this.vacancyService.deleteVacancy(this.vacancy.vacancyId).subscribe({
        next: () => {
          alert('Vacancy removed successfully!');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate([this.router.url]);
          // Optionally, refresh the vacancies or navigate to another page
        },
        error: () => {
          alert('Failed to remove vacancy.');
        },
      });
    }
  }

  // Navigate to the page showing applications for this vacancy
  viewApplications(): void {
    console.log(this.vacancy?.vacancyId);
    if (this.vacancy?.vacancyId) {
      this.router.navigate([`/applicationsByvacancy/${this.vacancy.vacancyId}`]);
    }
  }

  navigateToVacancyAnalysis(): void {
    if (this.vacancy?.vacancyId) {
      this.router.navigate(['/vacancyAnalysis'], { queryParams: { vacancyId: this.vacancy.vacancyId } });
    }
  }
}
