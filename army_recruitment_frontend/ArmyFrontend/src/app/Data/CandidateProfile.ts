export interface CandidateProfile {
    userId: string|null; // Guid as string
    fullName: string;
    dob: string; // Date as string
    qualifications: string;
    experience: string;
    profilePicture?: File; 
    militaryBackground: string;
  }