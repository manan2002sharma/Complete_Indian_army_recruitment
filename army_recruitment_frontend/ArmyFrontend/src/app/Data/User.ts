export interface User {
    userId: string;
    username: string;
    passwordHash?: string;
    role: 'Admin' | 'Recruiter' | 'Candidate' | 'Medical Officer';
    email: string;
    phoneNumber: string;
    isActive?: boolean;
    lastLogin?: Date;
  }