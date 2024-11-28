import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Task } from './task.model'; // Defina o DTO Task

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = ${environment.apiUrl}/api/task; // A URL da API

  constructor(private http: HttpClient) { }

  // Método para obter as tasks de um projeto específico
  getByProjectId(projectId: string): Observable<Task[]> {
    return this.http.get<Task[]>(${this.apiUrl}?projectId=${projectId});
  }

  // Método para obter uma task pelo ID
  getById(id: string): Observable<Task> {
    return this.http.get<Task>(${this.apiUrl}/${id});
  }

  // Método para criar uma nova task
  create(task: Task): Observable<Task> {
    return this.http.post<Task>(this.apiUrl, task);
  }

  // Método para atualizar uma task existente
  update(id: string, task: Task): Observable<void> {
    return this.http.put<void>(${this.apiUrl}/${id}, task);
  }

  // Método para excluir uma task
  delete(id: string): Observable<void> {
    return this.http.delete<void>(${this.apiUrl}/${id});
  }
}