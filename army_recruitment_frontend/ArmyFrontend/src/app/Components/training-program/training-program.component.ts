import { Component, Input } from '@angular/core';
import { TrainingProgram } from '../../Data/TrainingProgram';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ApplicationService } from '../../Services/application.service';

@Component({
  selector: 'app-training-program',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './training-program.component.html',
  styleUrl: './training-program.component.css'
})
export class TrainingProgramComponent {

  @Input() program: TrainingProgram =
    {
      trainingId: 'T1234',
      applicationId: 'A5678',
      title: 'Angular Training',
      location: 'New York',
      startDate: new Date('2024-01-15'),
      endDate: new Date('2024-01-20'),
      trainerName: 'John Doe',
      content: 'Comprehensive training on Angular, covering components, services, routing, and more.'
    };


  role: string | null = '';
  isEditable: boolean = false; // Allow editing for admins or recruiters

  constructor(private trainingProgramService: ApplicationService) {}

  ngOnInit() {
    this.role = localStorage.getItem('Userrole');
    if (this.role === 'Admin' || this.role === 'Recruiter') {
      this.isEditable = true;
    }
  }

  updateProgram() {
    const updatedProgram: TrainingProgram = {
      ...this.program
    };

    this.trainingProgramService.updateTrainingProgram(this.program.trainingId!, updatedProgram).subscribe({
      next: () => alert('Training Program updated successfully'),
      error: (err) => {
        console.error('Error updating program:', err);
        alert('Failed to update Training Program');
      }
    });
  }
}
