export interface DocumentVerification {
    verificationId?: string; // Guid as string
    candidateDocumentID?: string; // Foreign key for CandidateDocument
    documentType: string; // Cannot exceed 100 characters
    verificationStatus: string; // Cannot exceed 50 characters
    remarks?: string; // Optional, cannot exceed 500 characters
}