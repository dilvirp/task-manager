import './App.css'
import type { TaskItem } from './types/TaskItem'
import { useState } from 'react';
import TaskList from "./components/TaskList";
import TaskForm from "./components/TaskForm";

function App() {

  const [tasks, setTasks] = useState<TaskItem[]>([
    {
      id: 1,
      title: "Connect to the backend",
      isCompleted: false
    },
    {
      id: 2,
      title: "TaskItem test in React",
      isCompleted: true
    }]);

  function toggleTask(id: number) {
    setTasks((currentTasks) =>
      currentTasks.map((task) =>
        task.id === id ? { ...task, isCompleted: !task.isCompleted } : task
      )
    )
  }


  function addTask(title: string) {

    setTasks((currentTasks) => [
      ...currentTasks,
      {
        id: Math.max(0, ...currentTasks.map((task) => task.id)) + 1,
        title: title,
        isCompleted: false
      }
    ])
  }
  return (

    <main>
      <h1>Task Manager</h1>
      <p>Create, Organize, and complete your tasks.</p>

      <TaskForm onAdd={addTask}></TaskForm>

      <TaskList tasks={tasks} onToggle={toggleTask}></TaskList>
    </main>

  )
}
export default App
