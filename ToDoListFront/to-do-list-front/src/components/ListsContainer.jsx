import TasksGrid from "./TasksGrid";
import Nav from "./Nav"
import './style.css';

function ListsContainer() {

    return (
        <div className="lists-container">
            <Nav />
            <TasksGrid />
        </div>
    );
}

export default ListsContainer;