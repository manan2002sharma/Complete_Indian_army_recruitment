export interface Test{
    testId:string;
    applicationId:string;
    testType:string;
    date:Date;
    location:string;
    status?:string;
    remark?:string;
}