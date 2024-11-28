export interface Task {
  id: string;
  projectId: string;
  title: string;
  description: string;
  isCompleted: boolean;
  createdAt: string;
}