import { Component } from '@angular/core';
import { PlatformAccess } from '../../Data/PlatformAccess';
import { AuthService } from '../../Services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-platform-access',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './platform-access.component.html',
  styleUrl: './platform-access.component.css'
})
export class PlatformAccessComponent {
  platformAccessList: PlatformAccess[] = [
    {
      platformId: '93a61557-e432-4638-3084-08dd1526421c',
      userName: 'john_doe',
      deviceinfo: 'iPhone 12 Pro',
      accessDate: '2024-12-06T09:00:00Z',
    },
    {
      platformId: 'a2c78432-c4b1-42f9-b504-cf60b9825c38',
      userName: 'jane_smith',
      deviceinfo: 'Samsung Galaxy S21',
      accessDate: '2024-12-06T10:30:00Z',
    }
  ];

  constructor(private platformAccessService: AuthService) {}

  ngOnInit(): void {
    console.log('efef');
    this.platformAccessService.getAllPlatformAccess().subscribe((data) => {
      this.platformAccessList = data;
    });
  }
}
