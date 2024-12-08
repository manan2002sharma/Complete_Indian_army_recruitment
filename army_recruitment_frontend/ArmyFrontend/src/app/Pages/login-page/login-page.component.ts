import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../Services/auth.service';
import { Router } from '@angular/router';
import { DeviceDetectService } from '../../Services/device-detect.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  loginForm: FormGroup;
  errorMessage: string | null = null;
  deviceinfo:string | null =null;

  constructor(private fb: FormBuilder, private authService: AuthService,private router: Router, private deviceService: DeviceDetectService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;
      const deviceinfo = this.deviceService.getDeviceType();
      this.authService.login(username, password,deviceinfo).subscribe({
        next: (response) => {
          console.log('UserId',response.user.role);
          console.log('User:', response.user);
          console.log('Token:', response.token);
          
          localStorage.setItem('Userrole', response.user.role);
          localStorage.setItem('UserId', response.user.userId);
          localStorage.setItem('User', JSON.stringify(response.user));
          localStorage.setItem('authToken', response.token);
          localStorage.setItem('isLoggedIn', 'true');
          this.router.navigate(['/home']).then(() => {
            location.reload(); // Refresh the page after navigation
          });
        },
        error: () => {
          this.errorMessage = 'Invalid email or password.';
        }
      });
    }
  }
  navigateToSignUp(): void {
    this.router.navigate(['/signup']);
  }
}
