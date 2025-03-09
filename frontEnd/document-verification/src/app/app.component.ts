import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DocumentUploadComponent } from './document-upload/document-upload.component';
import { VerificationComponent } from './verification/verification.component';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadDocuments } from './store/document.actions';
import { Observable } from 'rxjs';
import { DocumentState } from './store/document.reducer';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    DashboardComponent,
    DocumentUploadComponent,
    VerificationComponent,
    RouterModule,
    CommonModule  
  ]
})
export class AppComponent implements OnInit{
  documents$: Observable<DocumentState>;
  loading$: Observable<boolean>;
  error$: Observable<string | null>;

  constructor(private store: Store<{ document: DocumentState }>) {
    this.documents$ = store.select('document');
    this.loading$ = store.select(state => state.document.loading);
    this.error$ = store.select(state => state.document.error);
  }

  ngOnInit(): void {
    this.store.dispatch(loadDocuments()); // Dispatch action to load documents
  }
}
