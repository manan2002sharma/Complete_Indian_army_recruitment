import { Component } from '@angular/core';
import { Application } from '../../Data/Application';
import { ApplicationService } from '../../Services/application.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-applications-by-vacancy-id',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './applications-by-vacancy-id.component.html',
  styleUrl: './applications-by-vacancy-id.component.css'
})
export class ApplicationsByVacancyIdComponent {
  applications: Application[] = [
    {
      applicationId: '1e9cfc50-82b4-4f87-a01b-76f4bca22b10',
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      vacancyId: '4a85c224-1f73-4312-9932-bf74e32d1ec0',
      applicationStatus: 'Under Review',
      submissionDate: '2024-12-01T10:15:30'
    },
    {
      applicationId: '9b83c170-b2fc-4207-9e32-7f2dcd1d6b3f',
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      vacancyId: '3fa85f64-5717-4562-b3fc-2c963f66aaa1',
      applicationStatus: 'Shortlisted',
      submissionDate: '2024-11-30T14:25:00'
    },
    {
      applicationId: 'b43dc581-87e7-4898-9dcb-9e2b1d24368c',
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      vacancyId: '2bc65c64-2a24-451d-ae68-9bfc123d66e1',
      applicationStatus: 'Rejected',
      submissionDate: '2024-11-28T09:00:00'
    },
    {
      applicationId: 'c15ef581-76e8-4310-a5e4-4c2b2d72fa91',
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      vacancyId: '1e2cd8f5-9c4f-4228-a8a4-6fb42c128b92',
      applicationStatus: 'Accepted',
      submissionDate: '2024-11-25T15:45:20'
    },
  ];
  vacancyId:string |null=null;
  errorMessage: string | null = null;
  role:string ='';

  constructor(private applicationService: ApplicationService,private router: Router,
    private route: ActivatedRoute,) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.vacancyId = params.get('vacancyId');
      console.log(this.vacancyId,'addds');
      if (this.vacancyId) {
        this.fetchApplications();
      }else{
        console.log('sd');
      }
    });
  }

  fetchApplications(): void {
    const userId = localStorage.getItem('UserId');
    const role = localStorage.getItem('Userrole');
    if (!userId) {
      this.errorMessage = 'User not logged in.';
      return;
    }
    this.applicationService.getApplicationsByVacancyId(this.vacancyId).subscribe({
      next: (data) => {
        this.applications = data;
      },
      error: (err) => {
        this.errorMessage = 'Failed to fetch applications. Please try again later.';
        console.error(err);
      },
    });
  }
  // goToApplicationDetails(applicationId: string,vacancyId:string): void {
  //   this.router.navigate(['/applications', applicationId], {
  //     queryParams: { vacancyId: vacancyId }
  //   });
  // }
  goToApplicationDetails(applicationId: string, vacancyId: string): void { 
    this.router.navigate(['/applications/'], {
      queryParams: { applicationId: applicationId, vacancyId: vacancyId }
    });
  }
}
