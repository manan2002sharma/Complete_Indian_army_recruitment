export interface VacancyExam{
    examId?:string;
    vacancyId?:string;
    examDate:Date;
    totalMarks:number;
    passingCriteria:number;
    examName?:string;
}