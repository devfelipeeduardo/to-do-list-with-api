import Task from './Task';

import './style.css';

function List({ title }) {

    return (
        <div className="list">
            <div className="list-title">{title}</div>
            <div className="add-task-container">
                <button className="add-task-button">+</button>
                <input className="add-task-input-text" type="text" placeholder="Insira sua tarefa"></input>
            </div>
            <div className="tasks-container">
                <Task placeholder="1" />
                <Task placeholder="2" />
                <Task placeholder="3" />
                <Task placeholder="4" />
                <Task placeholder="5" />
                <Task placeholder="6" />
                <Task placeholder="7" />
                <Task placeholder="8" />
                <Task placeholder="9" />
                <Task placeholder="10" />
            </div>
        </div>
    );
}

export default List;

