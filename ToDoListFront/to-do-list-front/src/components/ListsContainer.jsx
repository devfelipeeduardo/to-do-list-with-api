import ListsGrid from "./ListsGrid";
import Nav from "./Nav"
import './style.css';

function ListsContainer() {

    return (
        <div className="lists-container">
            <Nav />
            <ListsGrid />
        </div>
    );
}

export default ListsContainer;