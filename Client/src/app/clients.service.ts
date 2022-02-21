import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from './models/response';
import { Client } from './/models/client';

@Injectable({
  providedIn: 'root',
})
export class ClientsService {
  baseUrl = `${environment.apiUrl}/clients`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Response> {
    return this.http.get<Response>(this.baseUrl);
  }
  get(id: any): Observable<Response> {
    return this.http.get<Response>(`${this.baseUrl}/${id}`);
  }
  create(data: Client): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }
  update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, data);
  }
  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
