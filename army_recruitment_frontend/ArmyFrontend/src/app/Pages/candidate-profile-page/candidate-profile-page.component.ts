import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CandidateProfile } from '../../Data/CandidateProfile';
import { CommonModule } from '@angular/common';
import { ProfileService } from '../../Services/profile.service';
import { PlatformAccessComponent } from '../../Components/platform-access/platform-access.component';

@Component({
  selector: 'app-candidate-profile-page',
  standalone: true,
  imports: [FormsModule,CommonModule,PlatformAccessComponent],
  templateUrl: './candidate-profile-page.component.html',
  styleUrl: './candidate-profile-page.component.css'
})
export class CandidateProfilePageComponent  implements OnInit{
  profile: CandidateProfile ={
    userId: '', // Guid as string
    fullName: '',
    dob: '', // Date as string
    qualifications: '',
    experience: '',
    militaryBackground: ''
  };
  selectedFile: File | null = null;
  errorMessage: string | null = null;
  isEditing: boolean = false;
  profileExists: boolean = false;



  constructor(private profileService: ProfileService) {}


  ngOnInit(): void {
    this.loadProfile();
  }

  async loadProfile(): Promise<void> {
    try {
      const userId = localStorage.getItem('UserId');
      if (!userId) throw new Error('UserId not found in localStorage');

      const fetchedProfile = await this.profileService.getProfileByUserId(userId).toPromise();
      if (fetchedProfile) {
        this.profile = fetchedProfile;
        this.profileExists = true;
      } else {
        this.profile.userId = userId; // Prepare for profile addition
        this.profileExists = false;
      }
    } catch (error) {
      console.error('Error loading profile:', error);
      this.errorMessage = 'Add Profile Details';
    }
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  async onSubmit(): Promise<void> {
    try {
      this.profile.userId=localStorage.getItem('UserId');
      if (this.profile.userId == null) {
        throw new Error('No UserId found in localStorage');
      }
  
      const response = await this.profileService.addCandidateProfile(this.profile, this.selectedFile).toPromise();
      console.log('Profile added successfully:', response);
      alert('Profile added successfully.');
      
    } catch (error) {
      console.error('Error adding profile:', error);
      alert('An error occurred while adding the profile.');
    }
  }

  async onUpdate(): Promise<void> {
    try {
      this.profile.userId = localStorage.getItem('UserId');
      if (this.profile.userId == null) {
        throw new Error('No UserId found in localStorage');
      }

      const response = await this.profileService.updateCandidateProfile(this.profile, this.selectedFile).toPromise();
      console.log('Profile updated successfully:', response);
      alert('Profile updated successfully.');
      this.isEditing = false;
      this.loadProfile();
    } catch (error) {
      console.error('Error updating profile:', error);
      alert('An error occurred while updating the profile.');
    }
  }

}