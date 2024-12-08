import { Component, Input } from '@angular/core';
import { Test } from '../../Data/Test';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApplicationService } from '../../Services/application.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent {
  @Input() test: Test =     {
    testId: '5678',
    applicationId: 'efgh',
    testType: 'HR',
    date: new Date(),
    location: 'Los Angeles',
    status: 'Scheduled',
    remark:'sdf'
  };

  role: string | null = '';
  isEditable: boolean = false; // Flag to determine if the user can edit the remark and status

  constructor(private testUpdateService: ApplicationService) {}

  ngOnInit() {
    console.log(this.test);
    this.role = localStorage.getItem('Userrole'); // Get role from localStorage
    if (this.role === 'Medical Officer') {
      this.isEditable = true; // Allow editing for admins or recruiters
    }
    console.log(this.test);
  }

  // Function to update the test remark and status
  updateTest() {
    const updatedTest: Test = {
      ...this.test,
      status: this.test.status,
      remark: this.test.remark // Assuming remark is stored as 'remark' on the test object
    };

    this.testUpdateService.updateTest(this.test.testId, updatedTest).subscribe({
      next: (response) => {
        alert('Test updated successfully');
      },
      error: (err) => {
        console.error('Error updating test:', err);
        alert('Failed to update test');
      }
    });
  }

}
