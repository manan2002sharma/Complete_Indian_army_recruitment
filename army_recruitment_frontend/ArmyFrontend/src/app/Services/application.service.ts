import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from '../Data/Application';
import { DocumentSubmitted } from '../Data/DocumentSubmitted';
import { VacancyExamResult } from '../Data/VacancyExamResult';
import { Test } from '../Data/Test';
import { TrainingProgram } from '../Data/TrainingProgram';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  private baseUrl = 'https://localhost:7195/api';

  constructor(private http: HttpClient) {}

  getApplicationsByUserId(userId: string): Observable<Application[]> {
    return this.http.get<Application[]>(`${this.baseUrl}/Application/user/${userId}`);
  }

  getApplicationsByVacancyId(vacancyId: string|null): Observable<Application[]> {
    return this.http.get<Application[]>(`${this.baseUrl}/Application/vacancyId/${vacancyId}`);
  }

  getDocumentsByApplicationId(applicationId: string): Observable<DocumentSubmitted[]> {
    return this.http.get<DocumentSubmitted[]>(`${this.baseUrl}/CandidateDocument/applicationId/${applicationId}`);
  }
  getResultsByApplicationId(applicationId: string): Observable<VacancyExamResult[]> {
    return this.http.get<VacancyExamResult[]>(`${this.baseUrl}/VacancyExamResult/by-application/${applicationId}`);
  }
  getTestsByApplicationId(applicationId: string): Observable<Test[]> {
    return this.http.get<Test[]>(`${this.baseUrl}/Test/by-application/${applicationId}`);
  }
  getTrainingProgramsByApplicationId(applicationId: string): Observable<TrainingProgram[]> {
    return this.http.get<TrainingProgram[]>(`${this.baseUrl}/TrainingProgram/by-application/${applicationId}`);
  }

  addTrainingProgram(trainingProgram: TrainingProgram): Observable<TrainingProgram> {
    return this.http.post<TrainingProgram>(`${this.baseUrl}/TrainingProgram`, trainingProgram);
  }

  addTest(test: Test): Observable<Test> {
    return this.http.post<Test>(`${this.baseUrl}/Test`, test);
  }

  updateTest(testId: string, updatedTest: Test): Observable<any> {
    return this.http.put(`${this.baseUrl}/Test/${testId}`, updatedTest);
  }

  updateTrainingProgram(trainingId: string, updatedProgram: TrainingProgram ): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/TrainingProgram/${trainingId}`, updatedProgram);
  }
}
