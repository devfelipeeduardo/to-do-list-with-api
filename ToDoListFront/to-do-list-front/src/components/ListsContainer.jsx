import { useState } from "react";
import ListsGrid from "./ListsGrid";
import Nav from "./Nav"
import './style.css';

function ListsContainer() {

    const [lists, setLists] = useState([]);
    const [search, setSearch] = useState("");

    const filteredLists = lists.filter((list) =>
        list.title.toLowerCase().includes(search.toLowerCase())
    );


    return (
        <div className="lists-container">
            <Nav search={search} setSearch={setSearch} />
            <ListsGrid lists={filteredLists} setLists={setLists} /> 
        </div>
    );
}

export default ListsContainer;