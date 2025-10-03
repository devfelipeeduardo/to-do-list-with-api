import { useRef, useState } from 'react';
import Task from './Task';

import './style.css';

function List({ title }) {

    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState("");
    const inputRef = useRef(null);

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
        setTasks(tasks.filter((_, index) => index !== idToDelete));
    }

    const focusOnInput = () => {
        console.log(inputRef.current.value);
        inputRef.current.value = "";
        inputRef.current.focus(); // volta o foco
    };


    return (
        <div className="list">
            <div className="list-title">{title}</div>
            <div className="add-task-container">
                <button
                    className="add-task-button"
                    onClick={() => { handleAddTask(); focusOnInput(); }}
                >+</button>

                <input
                    ref={inputRef}
                    className="add-task-input-text"
                    type="text"
                    placeholder="Insira sua tarefa"
                    value={newTask}
                    onChange={(e) => setNewTask(e.target.value)}
                    onKeyDown={(e) => {
                        if (e.key === "Enter") {
                            handleAddTask();
                        }
                    }}
                    >
                </input>

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

