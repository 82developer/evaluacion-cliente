import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Client } from '../../core/models/client';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClientsService {
  private http = inject(HttpClient);
  private base = `${environment.apiUrl}/clients`;

  // List with optional search query
  getAll(query?: string): Observable<Client[]> {
    let params = new HttpParams();
    if (query && query.trim() !== '') {
      // json-server supports ?q=
      params = params.set('q', query.trim());
    }
    return this.http.get<Client[]>(this.base, { params });
  }

  getById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.base}/${id}`);
  }

  create(payload: Client): Observable<Client> {
    return this.http.post<Client>(this.base, payload);
  }

  update(id: number, payload: Client): Observable<Client> {
    return this.http.put<Client>(`${this.base}/${id}`, payload);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
}
