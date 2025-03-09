import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';  // Correct imports
import { DocumentService } from '../services/document.service'; // Assuming DocumentService
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-verification',
  imports:[ReactiveFormsModule,CommonModule],
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css'],
  standalone: true
})
export class VerificationComponent implements OnInit {
  verificationForm!: FormGroup;  // Declaration without direct initialization

  // Constructor - initialize FormBuilder and DocumentService
  constructor(private fb: FormBuilder, private documentService: DocumentService) {}

  ngOnInit(): void {
    // Initialize the form inside ngOnInit, after FormBuilder is injected
    this.verificationForm = this.fb.group({
      verificationCode: ['', Validators.required]
    });
  }

  onVerify(): void {
    if (this.verificationForm.valid) {
      // Retrieve the verification code, ensuring it is a string (defaults to empty string if null or undefined)
      const code = this.verificationForm.get('verificationCode')?.value ?? ''; 

      if (code) {  // Make sure the code is not an empty string
        this.documentService.verifyDocument(code).subscribe(
          (response) => {
            console.log('Document verified:', response);
          },
          (error) => {
            console.error('Verification failed:', error);
          }
        );
      } else {
        console.error('Verification code is required');
      }
    } else {
      console.error('Form is invalid');
    }
  }
}
