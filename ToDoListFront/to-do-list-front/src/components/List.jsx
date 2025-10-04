import { useRef, useState } from 'react';
import Task from './Task';

import './style.css';

function List({ title, deleteList }) {

    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState("");
    const inputRef = useRef(null);

    function addTask() {
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

    function deleteTask(idToDelete) {
        setTasks(tasks.filter(task => task.id !== idToDelete));
    }

    const focusOnInput = () => {
        console.log(inputRef.current.value);
        inputRef.current.value = "";
        inputRef.current.focus(); // volta o foco
    };


    return (
        <div className="list">
            <div className="list-title">
                {title}
                <button
                    className="delete-list-button"
                    onClick={deleteList}
                >
                    x
                </button>
            </div>

            <div className="add-task-container">
                <button
                    className="add-task-button"
                    onClick={() => { addTask(); focusOnInput(); }}
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
                            addTask();
                        }
                    }}
                >
                </input>

            </div>
            <div className="tasks-container">
                {tasks.map((task) => (
                    <Task
                        key={task.id}
                        placeholder={task.text}
                        deleteTask={() => deleteTask(task.id)}
                    />
                ))}
            </div>
        </div>
    );
}

export default List;

