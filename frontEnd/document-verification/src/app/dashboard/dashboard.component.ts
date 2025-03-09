import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../services/document.service';
import { CommonModule } from '@angular/common';

@Component({
  imports: [CommonModule],
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  // Local state management using component properties
  loading: boolean = false;
  documents: any[] = [];
  error: string | null = null;

  constructor(private documentService: DocumentService) {}

  ngOnInit(): void {
    this.loadDocuments();
  }

  loadDocuments(): void {
    // Set loading state before making the API call
    this.loading = true;

    // Call the document service to fetch documents
    this.documentService.getDocuments().subscribe(
      (data) => {
        // Set documents when API returns data
        this.documents = data;
        this.loading = false; // Stop loading when data is fetched
        this.error = null; // Reset any error
      },
      (error) => {
        // Set error state if the API fails
        this.error = error.message;
        this.loading = false;
      }
    );
  }
}
