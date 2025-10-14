import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Client } from '../../core/models/client';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClientsService {
  private http = inject(HttpClient);
  private base = `${environment.apiUrl}/clientes`;

  getAll(query?: any): Observable<any> {
    let params = this.toHttpParams(query);
    return this.http.get<any>(this.base+'/page', { params });
  }

  getById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.base}/${id}`);
  }

  create(payload: any): Observable<any> {
    return this.http.post<any>(this.base, payload);
  }

  update(id: number, payload: Client): Observable<Client> {
    return this.http.put<Client>(`${this.base}/${id}`, payload);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
  private toHttpParams(obj: Record<string, any>): HttpParams {
    let params = new HttpParams();
    for (const key in obj) {
      const value = obj[key];
      if (value !== undefined && value !== null && value !== '') {
        params = params.set(key, value);
      }
    }
    return params;
  }
}
