import { useState } from 'react';
import Task from './Task';

import './style.css';

function List({ title }) {

    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState("");

    function handleAddTask() {
        if (tasks.length == 9) {
            alert("Só é possível adicionar até 09 tarefas!")
            return;
        }
        
        if (newTask.trim() === "") return;

        const taskObject = {
            id: Date.now(),
            text: newTask
        };

        setTasks([...tasks, taskObject]);
        setNewTask("");


    }

    function handleDeleteTask(idToDelete) {
        setTasks(tasks.filter((_, index) => index!== idToDelete));
    }

    return (
        <div className="list">
            <div className="list-title">{title}</div>
            <div className="add-task-container">
                <button
                    className="add-task-button"
                    onClick={handleAddTask}
                >+</button>

                <input
                    className="add-task-input-text"
                    type="text"
                    placeholder="Insira sua tarefa"
                    value={newTask}
                    onChange={(e) => setNewTask(e.target.value)}></input>
            </div>
            <div className="tasks-container">
                {tasks.map((task, index) => (
                    <Task
                        key={task.id}
                        placeholder={task.text}
                        handleDeleteTask={() => handleDeleteTask(index)}
                    />
                ))}
            </div>
        </div>
    );
}

export default List;

