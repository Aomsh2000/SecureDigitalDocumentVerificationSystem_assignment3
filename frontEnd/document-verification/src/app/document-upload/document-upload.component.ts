import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { DocumentService } from '../services/document.service'; // Assuming DocumentService is available for API calls
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-document-upload',
  templateUrl: './document-upload.component.html',
  imports:[ReactiveFormsModule,CommonModule],
  styleUrls: ['./document-upload.component.css'],
  standalone: true
})
export class DocumentUploadComponent implements OnInit {
  uploadForm!: FormGroup;

  constructor(private fb: FormBuilder, private documentService: DocumentService) {}

  ngOnInit(): void {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      file: [null, Validators.required]
    });
  }

  // Handles file selection and patches it into the form control
  onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      this.uploadForm.patchValue({
        file: input.files[0]
      });
    }
  }

  // Handles form submission
  onSubmit(): void {
    if (this.uploadForm.valid) {
      const formData = new FormData();
      const file = this.uploadForm.get('file')?.value;
      const title = this.uploadForm.get('title')?.value;

      // Optional: Validate the file size or type if needed
      if (file && file.size > 5 * 1024 * 1024) {  // Max file size: 5MB
        console.error('File size exceeds the limit');
        return;
      }

            
        formData.append('file', file);
        formData.append('title', title);

        this.documentService.uploadDocument(formData).subscribe(
          (response) => {
            console.log('Document uploaded:', response);
          },
          (error) => {
            console.error('Upload failed:', error);
          }
        );

    } else {
      console.error('Form is invalid');
    }
  }
}
