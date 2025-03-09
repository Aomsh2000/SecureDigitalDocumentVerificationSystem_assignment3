import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  private apiUrl = 'http://localhost:5008/api'; // Adjust with your backend URL

  constructor(private http: HttpClient) {}

  getDocuments(): Observable<any> {
    return this.http.get(`${this.apiUrl}/documents`);
  }

  uploadDocument(formData: FormData): Observable<any> {
    return this.http.post(`${this.apiUrl}/upload`, formData);
  }

  verifyDocument(verificationCode: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/verify`, { verificationCode });
  }
}
