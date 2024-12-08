export interface VacancyExamResult{
    examResultId?: string; // Guid is represented as a string in JSON
    examId?: string; // Foreign key for VacancyExam
    applicationId: string; // Foreign key for Application
    score: number; // Score of the exam
    resultStatus: string; // Pass/Fail/Other
    examName?:string;
}