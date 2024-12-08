import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterModule,RouterOutlet,Routes } from '@angular/router';
import { ThemeService } from '../../Services/theme.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink,RouterOutlet],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{
  isloggedIn:boolean = false;
  isCandidate:boolean = false;
  isMobileMenuOpen = false;
  constructor(private themeService: ThemeService , private route : Router){}
  ngOnInit(): void {
    const loggedInStatus = localStorage.getItem('isLoggedIn');
    const userrole = localStorage.getItem('Userrole');
    this.isCandidate = userrole === 'Candidate';
    this.isloggedIn = loggedInStatus === 'true';
  }
  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }
  toggleTheme(): void {
    this.themeService.toggleDarkMode();
  }
  logout():void{
    localStorage.removeItem('isLoggedIn');
    window.location.reload();
  }

}
