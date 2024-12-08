import { User } from "./User";
import { VacancyExam } from "./VacancyExam";

export interface Vacancy{
    vacancyId?: string; // Guid is stored as string in JSON
    title: string;
    role: string;
    eligibilityCriteria: string;
    location: string;
    salary: number;
    postedBy: string|null; // Guid as string
    datePosted?: string; // Date as string
    status: string;
    postedByUser?:User;
    vacancyExams?:VacancyExam[];
}