import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vacancy } from '../Data/Vacancy';
import { RequireDocument } from '../Data/RequiredDocument';
import { VacancyExam } from '../Data/VacancyExam';
import { DocumentVerification } from '../Data/DocumentVerification';
import { DocumentSubmitted } from '../Data/DocumentSubmitted';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {
  private apiUrl = 'https://localhost:7195/api'; // Update with your actual API URL

  constructor(private http: HttpClient) {}

  getAllVacancies(UserId:string): Observable<Vacancy[]> {
    return this.http.get<Vacancy[]>(`${this.apiUrl}/Vacancy/ForUser/${UserId}`);
  }
  getRequiredDocuments(vacancyId: string): Observable<RequireDocument[]> {
    return this.http.get<RequireDocument[]>(`${this.apiUrl}/RequiredDocument/vacancy/${vacancyId}`);
  }

  addApplication(vacancyId: string, userId: string,vacancyName:string|null): Observable<string > {
    return this.http.post< string >(`${this.apiUrl}/Application/add`, {
      vacancyId,
      userId,
      vacancyName
    });
  }

  addCandidateDocument(
    document :DocumentSubmitted
  ): Observable<any> {
    return this.http.post(`${this.apiUrl}/CandidateDocument`, document,{ responseType: 'text' as 'json' });
  }

  addVacancy(vacancy: Vacancy): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/Vacancy`, vacancy);
  }

  deleteVacancy(vacancyId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Vacancy/${vacancyId}`);
  }

  addVacancyExam(exam: VacancyExam): Observable<VacancyExam> {
    return this.http.post<VacancyExam>(`${this.apiUrl}/VacancyExam`, exam);
  }

  addRequireDocument(doc: RequireDocument): Observable<RequireDocument> {
    return this.http.post<RequireDocument>(`${this.apiUrl}/RequiredDocument`, doc);
  }  
  getDocumentVerification(candidateDocumentID: string): Observable<DocumentVerification> {
    return this.http.get<DocumentVerification>(`${this.apiUrl}/CandidateDocument/${candidateDocumentID}`);
  }

  getVacancyAnalysis(vacancyId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/VacancyAnalysis/${vacancyId}`);
  }
}
