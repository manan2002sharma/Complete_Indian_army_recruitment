export interface TrainingProgram{
    trainingId?:string;
    applicationId?:string;
    title:string;
    location:string;
    startDate:Date;
    endDate:Date;
    trainerName:string;
    content:string;
    status?:string;
    remark?:string;
}