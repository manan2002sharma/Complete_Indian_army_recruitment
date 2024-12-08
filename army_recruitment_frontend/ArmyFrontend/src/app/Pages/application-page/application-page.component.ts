import { Component } from '@angular/core';
import { DocumentSubmitted } from '../../Data/DocumentSubmitted';
import { DocumentSubmittedComponent } from '../../Components/document-submitted/document-submitted.component';
import { VacancyExamResultComponent } from '../../Components/vacancy-exam-result/vacancy-exam-result.component';
import { VacancyExamResult } from '../../Data/VacancyExamResult';
import { Test } from '../../Data/Test';
import { TestComponent } from '../../Components/test/test.component';
import { TrainingProgram } from '../../Data/TrainingProgram';
import { TrainingProgramComponent } from '../../Components/training-program/training-program.component';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../../Services/application.service';
import { VacancyExamComponent } from '../../Components/vacancy-exam/vacancy-exam.component';

@Component({
  selector: 'app-application-page',
  standalone: true,
  imports: [DocumentSubmittedComponent,VacancyExamComponent,VacancyExamResultComponent,TestComponent,TrainingProgramComponent,CommonModule,FormsModule],
  templateUrl: './application-page.component.html',
  styleUrl: './application-page.component.css'
})
export class ApplicationPageComponent {

  applicationId: string | null = null;
  vacancyId: string | null = null;
  
  submittedDocuments: DocumentSubmitted[] = [

  ];
  examResults: VacancyExamResult[] = [
   
  ];

  testData: Test[] = [

  ];

  trainingData: TrainingProgram[] = [

  ];
  role:string|null = null;
  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService // Assuming this service fetches application details
  ) {}

  ngOnInit(): void {
    // Get the applicationId from the route parameters
    this.route.paramMap.subscribe(params => {
      this.route.queryParamMap.subscribe(queryParams => {
        this.applicationId = queryParams.get('applicationId'); // This should be the applicationId
      });
    
      // Get the vacancyId from the query parameters
      this.route.queryParamMap.subscribe(queryParams => {
        this.vacancyId = queryParams.get('vacancyId'); // This should be the vacancyId
      });
    
      this.role=localStorage.getItem('Userrole');
      console.log(this.applicationId,'gffg');
      console.log(this.vacancyId,'dfd');
      if (this.applicationId) {
        console.log('dddddddd');
        this.fetchDocuments(this.applicationId);
        this.fetchExamResults(this.applicationId);
        this.fetchTests(this.applicationId);
        this.fetchTrainingPrograms(this.applicationId);
      }
    });
  }

  fetchDocuments(applicationId: string): void {
    console.log(applicationId);
    this.applicationService.getDocumentsByApplicationId(applicationId).subscribe({
      next: (data) => {
        this.submittedDocuments = data;
      },
      error: (err) => {
        console.error('Error fetching documents:', err);
      }
    });
    console.log(this.submittedDocuments);
  }

  fetchExamResults(applicationId: string): void {
    this.applicationService.getResultsByApplicationId(applicationId).subscribe({
      next: (results) => {
        this.examResults = results;
      },
      error: (err) => {
        console.error(err);
      }
    });
    console.log(this.examResults);
  }

  fetchTests(applicationId: string): void {
    this.applicationService.getTestsByApplicationId(applicationId).subscribe({
      next: (data) => {
        this.testData = data;
      },
      error: (err) => {
        console.error('Error fetching tests:', err);
      }
    });
  }

  fetchTrainingPrograms(applicationId: string): void {
    console.log('adfdf',applicationId)
    this.applicationService.getTrainingProgramsByApplicationId(applicationId).subscribe({
      next: (data) => {
        this.trainingData = data;
      },
      error: (err) => {
        console.error('Error fetching training programs:', err);
      }
    });
  }
  


  addTrainingProgram(trainingForm: NgForm): void {
    if (!this.applicationId) {
      alert('Application ID is missing.');
      return;
    }
  
    const newTraining: TrainingProgram = {
      ...trainingForm.value,
      applicationId: this.applicationId,
    };
    console.log(newTraining);
    this.applicationService.addTrainingProgram(newTraining).subscribe({
      next: (training) => {
        alert('Training program added successfully!');
        this.trainingData.push(training); // Add the new training to the list
        trainingForm.reset();
      },
      error: (err) => {
        console.error('Error adding training program:', err);
        alert('Failed to add training program.');
      },
    });
  }
  
  addTest(testForm: NgForm): void {
    if (!this.applicationId) {
      alert('Application ID is missing.');
      return;
    }
  
    const newTest: Test = {
      ...testForm.value,
      applicationId: this.applicationId,
    };
    console.log(this.applicationId,'asdfadsfadsfadsfsadf');
    this.applicationService.addTest(newTest).subscribe({
      next: (test) => {
        alert('Test added successfully!');
        this.testData.push(test); // Add the new test to the list
        testForm.reset();
      },
      error: (err) => {
        console.error('Error adding test:', err);
        alert('Failed to add test.');
      },
    });
  }
}
