import { Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { SignupPageComponent } from './Pages/signup-page/signup-page.component';
import { CandidateProfilePageComponent } from './Pages/candidate-profile-page/candidate-profile-page.component';
import { ApplicationPageComponent } from './Pages/application-page/application-page.component';
import { AddVacancyPageComponent } from './Pages/add-vacancy-page/add-vacancy-page.component';
import { AllApplicationPageComponent } from './Pages/all-application-page/all-application-page.component';
import { ApplicationsByVacancyIdComponent } from './Pages/applications-by-vacancy-id/applications-by-vacancy-id.component';
import { VacancyAnalysisPageComponent } from './Pages/vacancy-analysis-page/vacancy-analysis-page.component';
import { authGuard } from './auth.guard';
import { LandingPageComponent } from './Pages/landing-page/landing-page.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent,canActivate:[authGuard] },
    { path: 'login', component: LoginPageComponent },
    { path: 'signup', component: SignupPageComponent },
    { path: 'test', component: LandingPageComponent},
    { path: 'profile', component:CandidateProfilePageComponent,canActivate:[authGuard] },
    {path:'application', component: AllApplicationPageComponent,canActivate:[authGuard]},
    {path:'addvacancy', component: AddVacancyPageComponent,canActivate:[authGuard]},
    {path :'applicationsByvacancy/:vacancyId', component:ApplicationsByVacancyIdComponent,canActivate:[authGuard]},
    {path: 'applications', component: ApplicationPageComponent,canActivate:[authGuard] },
    {path: 'vacancyAnalysis', component: VacancyAnalysisPageComponent,canActivate:[authGuard] },
    { path: '', redirectTo: 'test', pathMatch: 'full' },
    //{ path: '**', redirectTo: '/test' } // Redirect unknown paths to login
];