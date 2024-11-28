import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Project } from './project.model'; 

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private apiUrl = ${environment.apiUrl}/api/project;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }

  getById(id: string): Observable<Project> {
    return this.http.get<Project>(${this.apiUrl}/${id});
  }

  create(project: Project): Observable<Project> {
    return this.http.post<Project>(this.apiUrl, project);
  }

  update(id: string, project: Project): Observable<void> {
    return this.http.put<void>(${this.apiUrl}/${id}, project);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(${this.apiUrl}/${id});
  }
}