function Task({ placeholder, handleDeleteTask}) {

    return (
        <>
            <div className="task-row-container">
                <input className="task-input" type="text" placeholder={placeholder} />
                <button
                className="delete-task-button"
                onClick={handleDeleteTask}
                >x</button>
            </div>
        </>
    )
}

export default Task;