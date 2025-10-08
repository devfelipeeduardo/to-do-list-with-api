import { useEffect, useState } from "react";
import ListsGrid from "./ListsGrid";
import Nav from "./Nav"
import './style.css';

function ListsContainer() {

    const [lists, setLists] = useState([]);
    const [search, setSearch] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        console.log("aqui foi")
        fetch("http://localhost:5174/get-all-todo-lists") // ajuste a URL conforme seu backend
            .then((response) => {
                if (!response.ok) throw new Error("Erro ao buscar listas");
                console.log(response);
                return response.json();
                
            })
            .then((data) => {
                console.log("aqui entrou")
                console.log(data)
                // setLists(data)
            })
            .catch((error) => alert(error.message))
            .finally(() => setLoading(false));
    }, []);

    if (loading) return <div>Carregando...</div>

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