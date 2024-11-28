import { Component, OnInit } from '@angular/core';
import { Project } from '../models/project.model';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  projects: Project[] = [];
  project: Project = {
    id: '',
    name: '',
    description: '',
    createdAt: ''
  };

  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {
    this.loadProjects();
  }

  loadProjects() {
    this.projectService.getAll().subscribe((data) => {
      this.projects = data;
    });
  }

  onSubmit() {
    if (this.project.id) {
      // Atualizar
      this.projectService.update(this.project.id, this.project).subscribe(() => {
        this.loadProjects();
        this.resetForm();
      });
    } else {
      // Criar
      this.projectService.create(this.project).subscribe(() => {
        this.loadProjects();
        this.resetForm();
      });
    }
  }

  editProject(proj: Project) {
    this.project = { ...proj }; // Copia o objeto para edição
  }

  deleteProject(id: string) {
    this.projectService.delete(id).subscribe(() => {
      this.loadProjects();
    });
  }

  resetForm() {
    this.project = { id: '', name: '', description: '', createdAt: '' };
  }
}