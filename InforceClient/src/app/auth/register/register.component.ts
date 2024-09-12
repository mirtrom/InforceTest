import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Register } from '../../features/models/register.model';
import { AuthService } from '../../features/services/auth.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  errors: string[] = [];
  model: Register = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router, private cookieService: CookieService) { }

  onSubmit() {
    this.authService.register(this.model).subscribe({
      next: (response) => {
        console.log('Registration successful', response);
        this.authService.login(this.model).subscribe({
          next: (response) => {
            this.cookieService.set('Authorization', `Bearer ${response.token}`, undefined, '/', undefined, true, 'Strict');
            this.authService.setUser({
                email: this.model.email,
                roles: response.roles
              });
            this.router.navigate(['/']);
          },
          error: (error) => {
            console.log(error);
          }
        });
      },
      error: (error) => {
        console.error('Registration failed', error);
        this.errors = error.error.errors;
      }
    });
  }

}

