import { Component, Input } from '@angular/core';
import { VacancyExamResult } from '../../Data/VacancyExamResult';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-vacancy-exam-result',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './vacancy-exam-result.component.html',
  styleUrl: './vacancy-exam-result.component.css'
})
export class VacancyExamResultComponent {

  @Input() result: VacancyExamResult =     {
    examResultId: '1234',
    examId: '5678',
    applicationId: 'abcd',
    score: 85,
    resultStatus: 'Pass',
    examName:'random'
  };
}
