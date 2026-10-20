import type { TaskItem } from "../types/TaskItem";

interface TaskListProps {
    tasks: TaskItem[],
    onToggle: (id: number) => void;
}


export default function TaskList({ tasks, onToggle }: TaskListProps) {
    return (
        <ul>
            {tasks.map((task) => (
                <li key={task.id}>{task.title} - {task.isCompleted ? "Completed" : "Pending"}
                    <button onClick={() => onToggle(task.id)}>Toggle Completion</button></li>
            ))}
        </ul>
    )
}