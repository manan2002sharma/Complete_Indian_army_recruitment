import { Component, Input } from '@angular/core';
import { DocumentSubmitted } from '../../Data/DocumentSubmitted';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DocumentUpdateService } from '../../Services/document-update.service';

@Component({
  selector: 'app-document-submitted',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './document-submitted.component.html',
  styleUrl: './document-submitted.component.css'
})
export class DocumentSubmittedComponent {

  @Input() document: DocumentSubmitted =    {
    candidateDocumentId: '1234',
    applicationId: '5678',
    requiredDocumentId: 'abcd',
    filePath: 'https://example.com/doc1.pdf',
    submissionDate: new Date(),
    verificationStatus:'ad',
    remarks:'ad'
  };
  role: string | null = '';
  isEditable: boolean = false; // Flag to determine if the user can edit the remark and status

  constructor(private documentSubmittedService: DocumentUpdateService) {}

  ngOnInit() {
    console.log(this.document);
    this.role = localStorage.getItem('Userrole'); // Get role from localStorage
    if (this.role === 'Admin' || this.role === 'Recruiter') {
      this.isEditable = true; // Allow editing for admins or recruiters
    }
  }

  // Function to update the document remark and status
  updateDocument() {
    const updatedDocument: DocumentSubmitted = {
      ...this.document,
      remarks: this.document.remarks,
      verificationStatus: this.document.verificationStatus,
      //documentType:'ddss'
    };

    this.documentSubmittedService.updateDocument(this.document.candidateDocumentId, updatedDocument).subscribe({
      next: (response) => {
        alert('Document updated successfully');
      },
      error: (err) => {
        console.error('Error updating document:', err);
        alert('Failed to update document');
      }
    });
  }
}
