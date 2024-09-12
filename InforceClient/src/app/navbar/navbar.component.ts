import { Component, OnInit } from '@angular/core';
import { AuthService } from '../features/services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { User } from '../features/models/user.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent implements OnInit {
  user: User | undefined;
  constructor(private authServise: AuthService, private router: Router) { }
  ngOnInit(): void {
    this.authServise.user().subscribe(user => {
      console.log(user)
      this.user = user;
    });

    this.user = this.authServise.getUser();
  }
  onLogout() {
    this.authServise.logout();
    this.router.navigate(['/']);
  }
}
