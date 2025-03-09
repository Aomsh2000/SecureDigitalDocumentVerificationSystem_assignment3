import { Component } from '@angular/core';
import { RouterModule } from '@angular/router'; // Import RouterModule for routing
import { DashboardComponent } from './dashboard/dashboard.component';
import { DocumentUploadComponent } from './document-upload/document-upload.component';
import { VerificationComponent } from './verification/verification.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    DashboardComponent,
    DocumentUploadComponent,
    VerificationComponent,
    RouterModule // Include RouterModule if you're using routing
  ]
})
export class AppComponent {
  // AppComponent logic here
}
