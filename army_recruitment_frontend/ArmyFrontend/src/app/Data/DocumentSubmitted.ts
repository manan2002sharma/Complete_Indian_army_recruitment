export interface DocumentSubmitted{
    candidateDocumentId?:string;
    applicationId?:string;
    documentType?:string;
    requiredDocumentId?:string;
    filePath:string;
    submissionDate:Date;
    verificationStatus?:string;
    remarks?:string;
}