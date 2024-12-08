import { Component, OnInit } from '@angular/core';
import { Vacancy } from '../../Data/Vacancy';
import { VacancyExam } from '../../Data/VacancyExam';
import { RequireDocument } from '../../Data/RequiredDocument';
import { VacancyService } from '../../Services/vacancy.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-vacancy-page',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './add-vacancy-page.component.html',
  styleUrl: './add-vacancy-page.component.css'
})
export class AddVacancyPageComponent implements OnInit {
  vacancy: Vacancy = {
    title: '',
    role: '',
    eligibilityCriteria: '',
    location: '',
    salary: 0,
    postedBy: '',
    status: ''
  };
  vacancyExams: VacancyExam[] = [];
  requiredDocuments: RequireDocument[] = [];

  constructor(private vacancyService: VacancyService, private router: Router) {}

  ngOnInit(): void {
  }

  addExam(): void {
    this.vacancyExams.push({  vacancyId : '',examDate: new Date(), totalMarks: 0, passingCriteria: 0 , examName:""});
  }

  addDocument(): void {
    this.requiredDocuments.push({ documentType: '', description: '' });
  }

  // submit(): void {
  //   // Step 1: Add the vacancy and get the vacancyId
  //   console.log(this.vacancy,this.vacancyExams,this.requiredDocuments);
  //   this.vacancy.postedBy=localStorage.getItem('UserId');
  //   this.vacancyService.addVacancy(this.vacancy).subscribe((vacancyResponse) => {
  //     const vacancyId = vacancyResponse;

  //     // Step 2: Add exams for this vacancy
  //     this.vacancyExams.forEach((exam) => {
  //       exam.VacancyId = vacancyId;
  //       this.vacancyService.addVacancyExam(exam).subscribe();
  //     });

  //     // Step 3: Add required documents for this vacancy
  //     this.requiredDocuments.forEach((doc) => {
  //       doc.VacancyId = vacancyId;
  //       this.vacancyService.addRequireDocument(doc).subscribe();
  //     });
  //   });
  // }

  submit(): void {
    console.log(this.vacancy, this.vacancyExams, this.requiredDocuments);
  
    // Set the user who posted the vacancy
    this.vacancy.postedBy = localStorage.getItem('UserId');
  
    // Step 1: Add the vacancy and get the vacancyId
    this.vacancyService.addVacancy(this.vacancy).subscribe({
      next: (vacancyResponse) => {
        const vacancyId = vacancyResponse;
  
        // Step 2: Add exams for this vacancy
        let examsCompleted = 0;
        let docsCompleted = 0;
        let hasError = false;
  
        this.vacancyExams.forEach((exam) => {
          exam.vacancyId = vacancyId;
          this.vacancyService.addVacancyExam(exam).subscribe({
            next: () => {
              examsCompleted++;
              this.checkCompletion(examsCompleted, docsCompleted, hasError, vacancyId);
            },
            error: () => {
              hasError = true;
              alert('Error adding exam. Please try again.');
            },
          });
        });
  
        // Step 3: Add required documents for this vacancy
        this.requiredDocuments.forEach((doc) => {
          doc.vacancyId = vacancyId;
          this.vacancyService.addRequireDocument(doc).subscribe({
            next: () => {
              docsCompleted++;
              this.checkCompletion(examsCompleted, docsCompleted, hasError, vacancyId);
            },
            error: () => {
              hasError = true;
              alert('Error adding document. Please try again.');
            },
          });
        });
      },
      error: () => {
        alert('Failed to add vacancy. Please try again.');
      },
    });
  }
  
  // Helper function to check completion and navigate if successful
  private checkCompletion(
    examsCompleted: number,
    docsCompleted: number,
    hasError: boolean,
    vacancyId: string
  ): void {
    if (
      examsCompleted === this.vacancyExams.length &&
      docsCompleted === this.requiredDocuments.length &&
      !hasError
    ) {
      alert(`Vacancy ${vacancyId} added successfully!`);
      this.router.navigate(['/home']);
    }
  }


}
