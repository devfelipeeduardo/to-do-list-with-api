import './style.css';

function List({ title }) {

    return (
        <div className="list">
            <div className="list-title">{title}</div>
            <div className="button-and-tasktext">
                <button className="add-task-button">+</button>
                <input className="input-new-task" type="text" placeholder="tarefa"></input>
            </div>
            <div className="tasks-container">
                <input className="task" type="text" placeholder="1" />
                <input className="task" type="text" placeholder="2" />
                <input className="task" type="text" placeholder="3" />
                <input className="task" type="text" placeholder="4" />
                <input className="task" type="text" placeholder="5" />
                <input className="task" type="text" placeholder="6" />
                <input className="task" type="text" placeholder="7" />
                <input className="task" type="text" placeholder="8" />
                <input className="task" type="text" placeholder="9" />
                <input className="task" type="text" placeholder="10" />
            </div>
        </div>
    );
}

export default List;

