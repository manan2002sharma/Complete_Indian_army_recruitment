import { Component, Input } from '@angular/core';
import { VacancyExamService } from '../../Services/vacancy-exam.service';
import { VacancyExam } from '../../Data/VacancyExam';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { VacancyExamResult } from '../../Data/VacancyExamResult';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vacancy-exam',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './vacancy-exam.component.html',
  styleUrl: './vacancy-exam.component.css'
})
export class VacancyExamComponent {
  @Input() vacancyId: string | null = null;
  @Input() applicationId: string | null = null;

  exams: VacancyExam[] = [
    {
      examId: 'exam1',
      vacancyId: 'vacancy1',
      examDate: new Date('2024-12-10T10:00:00'),
      totalMarks: 100,
      passingCriteria: 50,
      examName:'dadf'
    }
  ];
  errorMessage: string | null = null;
  isAdminOrRecruiter: boolean = false;

  // Form data for posting results
  currentExamId: string | undefined = '';
  currentExamName : string | undefined ='';
  resultForm = {
    score: 0,
    resultStatus: ''
  };

  constructor(private vacancyExamService: VacancyExamService,private router: Router) {}

  ngOnInit(): void {
    const role = localStorage.getItem('Userrole');
    this.isAdminOrRecruiter = role === 'Admin' || role === 'Recruiter';
    if (this.vacancyId) {
      this.fetchVacancyExams();
    }
  }

  fetchVacancyExams(): void {
    if (this.vacancyId) {
      this.vacancyExamService.getVacancyExams(this.vacancyId).subscribe({
        next: (data) => {
          this.exams = data;
      console.log(this.exams);
        },
        error: () => {
          this.errorMessage = 'Failed to load exams. Please try again later.';
        },
      });
    }
  }

  openResultForm(examId: string | undefined,examName : string | undefined): void {
    this.currentExamId = examId;
    this.currentExamName = examName;
    this.resultForm = { score: 0, resultStatus: '' };
  }

  postExamResult(): void {
    if (!this.applicationId || !this.currentExamId) {
      alert('Application ID or Exam ID is missing.');
      return;
    }

    const examResult: VacancyExamResult = {
      examId: this.currentExamId,
      applicationId: this.applicationId,
      score: this.resultForm.score,
      resultStatus: this.resultForm.resultStatus,
      examName:this.currentExamName
    };

    this.vacancyExamService.postVacancyExamResult(examResult).subscribe({
      next: () => {
        alert('Exam result posted successfully!');
        this.currentExamId = '';
        window.location.reload()
      },
      error: () => {
        alert('Failed to post exam result. Please try again.');
      },
    });
  }
}
