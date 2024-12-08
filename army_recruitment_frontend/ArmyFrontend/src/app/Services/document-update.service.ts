import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DocumentSubmitted } from '../Data/DocumentSubmitted';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DocumentUpdateService {
  private apiUrl = 'https://localhost:7195/api/CandidateDocument'; // Replace with your backend API URL

  constructor(private http: HttpClient) {}

  // Method to update candidate document
  updateDocument(id: string|undefined, document: DocumentSubmitted): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, document,{ responseType: 'text' as 'json' });
  }
}
