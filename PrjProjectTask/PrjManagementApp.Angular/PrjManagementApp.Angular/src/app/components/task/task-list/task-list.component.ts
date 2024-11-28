import { Component, OnInit } from '@angular/core';
import { Task } from '../../models/task.model';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent implements OnInit {
  tasks: Task[] = [];
  task: Task = this.resetTask();
  projectId!: string;

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // Obter o ID do projeto atual (via rota, por exemplo)
    this.route.params.subscribe(params => {
      this.projectId = params['projectId'];
      this.loadTasks();
    });
  }

  loadTasks(): void {
    this.taskService.getByProjectId(this.projectId).subscribe({
      next: (data) => (this.tasks = data),
      error: (err) => console.error('Failed to load tasks:', err),
    });
  }

  onSubmit(): void {
    if (this.task.id) {
      this.taskService.update(this.task.id, this.task).subscribe(() => {
        this.loadTasks();
        this.resetForm();
      });
    } else {
      this.task.projectId = this.projectId;
      this.taskService.create(this.task).subscribe(() => {
        this.loadTasks();
        this.resetForm();
      });
    }
  }

  editTask(task: Task): void {
    this.task = { ...task };
  }

  deleteTask(id: string): void {
    if (confirm('Are you sure you want to delete this task?')) {
      this.taskService.delete(id).subscribe(() => this.loadTasks());
    }
  }

  resetForm(): void {
    this.task = this.resetTask();
  }

  private resetTask(): Task {
    return {
      id: '',
      projectId: '',
      title: '',
      description: '',
      isCompleted: false,
      createdAt: ''
    };
  }
}