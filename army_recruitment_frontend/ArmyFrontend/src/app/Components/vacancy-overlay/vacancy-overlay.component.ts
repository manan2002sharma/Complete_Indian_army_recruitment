import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { VacancyService } from '../../Services/vacancy.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RequireDocument } from '../../Data/RequiredDocument';
import { DocumentSubmitted } from '../../Data/DocumentSubmitted';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vacancy-overlay',
  standalone: true,
  imports: [FormsModule,CommonModule ],
  templateUrl: './vacancy-overlay.component.html',
  styleUrl: './vacancy-overlay.component.css'
})
export class VacancyOverlayComponent {
  @Input() vacancyId: string | null = null;
  @Input() vacancyName : string | null = null;
  @Output() closeOverlay = new EventEmitter<boolean>();

  requiredDocuments: RequireDocument[] = [
    { 
      requiredDocumentId:'',
      vacancyId:'',
      documentType:'aadhar',
      description:'aplfa'
    }
  ]; // Documents fetched from the backend
  requireLinks: string[] = []; // Links provided by the user, one for each document

  constructor(private vacancyService: VacancyService,private router: Router) {}


  ngOnInit(): void {
    this.fetchRequiredDocuments();
  }

  fetchRequiredDocuments(): void {
    if (this.vacancyId) {
      this.vacancyService.getRequiredDocuments(this.vacancyId).subscribe((documents) => {
        this.requiredDocuments = documents;
        this.requireLinks = new Array(documents.length).fill(''); // Initialize requireLinks
        console.log(this.requiredDocuments);
      });
    }
  }

  submitApplication(): void {
    const userId = localStorage.getItem('UserId');
    console.log(userId);
    if (!userId || !this.vacancyId) {
      console.error('User ID or Vacancy ID is missing.');
      return;
    }

    this.vacancyService.addApplication( this.vacancyId,userId,this.vacancyName).subscribe({
      next: (applicationId) => {
        this.uploadDocuments(applicationId);
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate([this.router.url]);

      },
      error: (err) => console.error('Application submission failed:', err),
    });
  }

  uploadDocuments(applicationId: string): void {
    const uploadTasks = this.requiredDocuments.map((doc, index) => {
      const documentData: DocumentSubmitted = {
        applicationId:applicationId,
        requiredDocumentId : doc.requiredDocumentId,
        filePath: this.requireLinks[index],
        submissionDate: new Date(),
        documentType:doc.documentType
      };

      return this.vacancyService.addCandidateDocument(documentData).toPromise();
    });

    Promise.all(uploadTasks)
      .then(() => {
        console.log('All documents uploaded successfully.');
        this.close();
      })
      .catch((err) => console.error('Error uploading documents:', err));
  }

  close(): void {
    this.closeOverlay.emit(false);
  }
}

