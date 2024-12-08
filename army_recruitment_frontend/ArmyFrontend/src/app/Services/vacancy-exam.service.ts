import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VacancyExam } from '../Data/VacancyExam';
import { VacancyExamResult } from '../Data/VacancyExamResult';

@Injectable({
  providedIn: 'root'
})
export class VacancyExamService {
  private apiUrl = 'https://localhost:7195/api'; // Replace with actual API base URL

  constructor(private http: HttpClient) {}

  getVacancyExams(vacancyId: string): Observable<VacancyExam[]> {
    return this.http.get<VacancyExam[]>(`${this.apiUrl}/VacancyExam/vacancy/${vacancyId}`);
  }

  postVacancyExamResult(examResult: VacancyExamResult): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/VacancyExamResult`, examResult);
  }
}
