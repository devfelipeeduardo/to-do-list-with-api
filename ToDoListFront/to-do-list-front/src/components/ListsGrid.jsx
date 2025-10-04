import { useState } from 'react';
import List from './List';
import './style.css';

function ListsGrid() {

    const [lists, setLists] = useState([]);
    const [newList, setNewList] = useState("");

    function handleAddList() {
        if (lists.length == 8) {
            alert("Só é possível adicionar até 08 listas de tarefas!")
            return;
        }

        if (newList.trim() === "")

        setLists([...lists, newList]);

    }

    return (
        <main className="tasks-grid">
            <List title ="Comidas"/>
            <List title ="Bebidas"/>
            <List title ="Petshop"/>
            <List title ="Tecnologia"/>
            <List title ="Estudos"/>
            <List title ="Trabalho"/>
            <List title ="Limpeza"/>
            <List title ="Outros"/>
        </main>
    );
}

export default ListsGrid;

