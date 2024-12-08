import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private darkModeEnabled = false;
  constructor() { }
  toggleDarkMode(): void {
    this.darkModeEnabled = !this.darkModeEnabled;
    if (this.darkModeEnabled) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark');
    }
    localStorage.setItem('theme', this.darkModeEnabled ? 'dark' : 'light');
    console.log(this.darkModeEnabled);
  }

  loadTheme(): void {
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme === 'dark') {
      this.darkModeEnabled = true;
      document.documentElement.classList.add('dark');
    }
  }
}
