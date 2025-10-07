function Task({ placeholder, deleteTask}) {

    return (
        <>
            <div className="task-row-container">
                <input
                type="checkbox"
                className="checkbox-task"/>

                <input
                className="task-input"
                type="text"
                placeholder={placeholder} />

                <button
                className="delete-task-button"
                onClick={deleteTask}
                >x</button>
            </div>
        </>
    )
}

export default Task;