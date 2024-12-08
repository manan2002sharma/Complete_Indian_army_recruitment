import { DocumentSubmitted } from "./DocumentSubmitted";
import { Test } from "./Test";
import { TrainingProgram } from "./TrainingProgram";
import { VacancyExamResult } from "./VacancyExamResult";

export interface Application{
    applicationId: string;
    userId: string;
    vacancyId:string;
    applicationStatus:string;
    submissionDate:string;
    vacancyName?:string;
}