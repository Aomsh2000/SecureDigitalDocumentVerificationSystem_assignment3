import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../services/document.service'; // Assuming you have a DocumentService
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  standalone: true,
  imports: [CommonModule]
})


export class DashboardComponent implements OnInit {
  documents: any[] = [];

  constructor(private documentService: DocumentService) {}

  ngOnInit(): void {
    this.loadDocuments();
  }

  loadDocuments(): void {
    this.documentService.getDocuments().subscribe((data) => {
      this.documents = data;
    });
  }
}
