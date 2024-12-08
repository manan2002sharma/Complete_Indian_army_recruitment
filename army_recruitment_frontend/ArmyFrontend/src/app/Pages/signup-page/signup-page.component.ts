import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../Services/auth.service';
import { User } from '../../Data/User';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup-page',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.css'
})
export class SignupPageComponent {
  signupForm: FormGroup;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.signupForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      role: ['Candidate', [Validators.required]],
      passwordHash: ['',[Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^(\+\d{1,3}[- ]?)?\d{10}$/)]],
    });
  }

  onSubmit(): void {
    if (this.signupForm.valid) {
      const user: User = this.signupForm.value;
      console.log(user);
      this.authService.signup(user).subscribe({
        next: (response) => {
          this.successMessage = response.message;
          this.router.navigate(['/login']);
        },
        error: (e) => {
          this.errorMessage = e.error.error;
        }
      });
    }else{
      console.log("ddd");
      this.successMessage = null;
      this.errorMessage = 'Please fix the errors in the form.';
    }
  }
  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }
}
