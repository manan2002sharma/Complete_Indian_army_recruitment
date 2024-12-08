import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { ThemeService } from './Services/theme.service';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HomeComponent,NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ArmyFrontend';
  constructor(private themeService: ThemeService) {
    this.themeService.loadTheme();
  }

  toggleTheme(): void {
    this.themeService.toggleDarkMode();
  }
}
