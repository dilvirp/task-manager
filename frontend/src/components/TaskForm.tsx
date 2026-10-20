import { useState } from 'react';

interface TaskFormProps {
    onAdd: (title: string) => void;
}

export default function TaskForm({ onAdd }: TaskFormProps) {
    const [newTitle, setNewTitle] = useState('');

    return (
        <form onSubmit={(event) => {
            event.preventDefault();

            const title = newTitle.trim();

            if (title === '') {
                return;
            }

            onAdd(newTitle);
            setNewTitle('');
        }
        }>
            <label htmlFor='task-title'>Task Title</label>
            <input id="task-title" type='text' value={newTitle}
                onChange={(event) => setNewTitle(event.target.value)}></input>
            <p>{newTitle}</p>

            <button type="submit">Add Task</button>
        </form >

    )

}
