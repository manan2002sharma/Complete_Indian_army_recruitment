import { Injectable } from '@angular/core';
import { CandidateProfile } from '../Data/CandidateProfile';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private apiUrl ='https://localhost:7195/api';

  constructor(private http: HttpClient) { }
  addCandidateProfile(profile: CandidateProfile, profilePicture: File|null): Observable<any> {
    const formData = new FormData();

    // Append profile fields to FormData
    Object.keys(profile).forEach(key => {
      if (profile[key as keyof CandidateProfile] !== undefined){
        formData.append(key, profile[key as keyof CandidateProfile] as string);
      }
    });

    // Append the file
    if (profilePicture) {
      formData.append('profilePicture', profilePicture);
    }

    return this.http.post(`${this.apiUrl}/CandidateProfile`, formData,{ responseType: 'text' as 'json' });
  }

  getProfileByUserId(userId: string): Observable<CandidateProfile | null> {
    const url = `${this.apiUrl}/CandidateProfile/${userId}`;
    return this.http.get<CandidateProfile | null>(url);
  }


  updateCandidateProfile(profile: CandidateProfile, file: File|null): Observable<any> {
    const formData = new FormData();
  
    Object.keys(profile).forEach(key => {
      if (profile[key as keyof CandidateProfile] !== undefined){
        formData.append(key, profile[key as keyof CandidateProfile] as string);
      }
    });
  
    if (file) {
      formData.append('profilePicture', file);
    }
  
    return this.http.put(`${this.apiUrl}/CandidateProfile`, formData, {headers: new HttpHeaders({Accept: 'application/json',}),});
  }
}
