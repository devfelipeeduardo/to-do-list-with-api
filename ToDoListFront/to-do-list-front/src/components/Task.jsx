function Task({ placeholder }) {


    return (
        <>
            <div className="task-row-container">
                <input className="task-input" type="text" placeholder={placeholder} />
                <button className="delete-task-button">x</button>
            </div>
        </>
    )

}

export default Task;