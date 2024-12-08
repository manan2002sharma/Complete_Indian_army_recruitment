// import { Component } from '@angular/core';
// import { Vacancy } from '../../Data/Vacancy';
// import { VacancyService } from '../../Services/vacancy.service';
// import { VacancyComponent } from '../../Components/vacancy/vacancy.component';
// import { CommonModule } from '@angular/common';
// import { Router } from '@angular/router';

// @Component({
//   selector: 'app-home',
//   standalone: true,
//   imports: [VacancyComponent,CommonModule],
//   templateUrl: './home.component.html',
//   styleUrl: './home.component.css'
// })
// export class HomeComponent {
//   vacancies: Vacancy[] = [
//     {
//     vacancyId: 'aadfd', // Guid is stored as string in JSON
//     title:' string;',
//     role: 'string;',
//     eligibilityCriteria: 'string;',
//     location: 'string;',
//     salary: 103003,
//     postedBy: 'string;', // Guid as string
//     datePosted: 'string;', // Date as string
//     status: 'string;'
//     }
//   ];
//   errorMessage: string | null = null;
//   role:string | null =null;
//   UserId:string | null = null;

//   constructor(private vacancyService: VacancyService,private router: Router) {}

//   ngOnInit(): void {
//     this.fetchVacancies();
//     this.role=localStorage.getItem('Userrole');
//   }

//   fetchVacancies(): void {
//     this.UserId=localStorage.getItem("UserId");
//     if(this.UserId==null){
//       alert('Login again');
//       return;
//     }
//     this.vacancyService.getAllVacancies(this.UserId).subscribe({
//       next: (data) => {
//         this.vacancies = data;
//       },
//       error: () => {
//         this.errorMessage = 'Failed to load vacancies. Please try again later.';
//       },
//     });
//   }

//   navigateToAddVacancy(): void {
//     this.router.navigate(['/addvacancy']);
//   }
// }


import { Component } from '@angular/core';
import { Vacancy } from '../../Data/Vacancy';
import { VacancyService } from '../../Services/vacancy.service';
import { VacancyComponent } from '../../Components/vacancy/vacancy.component';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [VacancyComponent, CommonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  vacancies: Vacancy[] = [
    {
      vacancyId: '3c4d5e6f-7890-3456-1234-cdef12345678',
      title: 'Project Manager',
      role: 'Manager',
      eligibilityCriteria: 'Master\'s degree in Business Administration, PMP certification',
      location: 'Mumbai',
      salary: 1200000,
      postedBy: '3456cdef-7890-ghij-1234-klmnop3456',
      datePosted: '2024-11-25T09:30:00Z',
      status: 'Open'
    },
    {
      vacancyId: '4d5e6f7g-8901-4567-2345-def123456789',
      title: 'Network Engineer',
      role: 'Engineer',
      eligibilityCriteria: 'Bachelor\'s degree in IT, CCNA certification',
      location: 'Pune',
      salary: 700000,
      postedBy: '4567def1-8901-hijk-2345-mnopq4567',
      datePosted: '2024-11-20T08:00:00Z',
      status: 'Closed'
    },
    {
      vacancyId: '5e6f7g8h-9012-5678-3456-ef1234567890',
      title: 'Marketing Specialist',
      role: 'Marketing',
      eligibilityCriteria: 'Bachelor\'s degree in Marketing, 3+ years of experience',
      location: 'Delhi',
      salary: 800000,
      postedBy: '5678ef12-9012-ijkl-3456-nopqr5678',
      datePosted: '2024-11-15T10:15:00Z',
      status: 'Open'
    }
  ];
  filteredVacancies: Vacancy[] = [];
  errorMessage: string | null = null;
  role: string | null = null;
  UserId: string | null = null;

  searchLocation: string = '';
  searchCriteria: string = '';

  constructor(private vacancyService: VacancyService, private router: Router) {}

  ngOnInit(): void {
    this.fetchVacancies();
    this.role = localStorage.getItem('Userrole');
    console.log(this.role);
  }

  fetchVacancies(): void {
    this.UserId = localStorage.getItem('UserId');
    if (this.UserId == null) {
      alert('Login again');
      return;
    }
    this.vacancyService.getAllVacancies(this.UserId).subscribe({
      next: (data) => {
        this.vacancies = data;
        this.filteredVacancies = [...data]; // Show all vacancies initially
      },
      error: () => {
        this.errorMessage = 'Failed to load vacancies. Please try again later.';
      },
    });
  }

  applyFilters(): void {
    this.filteredVacancies = this.vacancies.filter((vacancy) => {
      const matchesLocation = vacancy.location
        .toLowerCase()
        .includes(this.searchLocation.toLowerCase());
      const matchesCriteria = vacancy.eligibilityCriteria
        .toLowerCase()
        .includes(this.searchCriteria.toLowerCase());
      return matchesLocation && matchesCriteria;
    });
  }

  clearFilters(): void {
    this.searchLocation = '';
    this.searchCriteria = '';
    this.filteredVacancies = [...this.vacancies]; // Reset filtered data
  }

  navigateToAddVacancy(): void {
    this.router.navigate(['/addvacancy']);
  }
}



