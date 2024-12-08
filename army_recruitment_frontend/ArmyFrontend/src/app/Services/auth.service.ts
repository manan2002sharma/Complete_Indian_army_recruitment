import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Data/User';
import { Observable } from 'rxjs';
import { PlatformAccess } from '../Data/PlatformAccess';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private SignupUrl = 'https://localhost:7195/api/User/Signup/signup';
  private LoginUrl='https://localhost:7195/api/User/Login/login';
  private PlatformUrl ='https://localhost:7195/api/User/GetAllPlatformAccess/PlatformAccess';
  constructor(private http: HttpClient) {}

  login(username: string, password: string , deviceinfo: string): Observable<{ token: string; user: User }> {

    return this.http.post<{ token: string; user: User }>(this.LoginUrl, { username,password,deviceinfo });
 
  }

  signup(user: Partial<User>): Observable<{ message: string }> {
    return this.http.post<{ message: string }>(`${this.SignupUrl}`, { ...user});
  }

  getAllPlatformAccess(): Observable<PlatformAccess[]> {
    return this.http.get<PlatformAccess[]>(this.PlatformUrl);
  }
}
