import { useEffect, useState, useRef } from 'react';
import List from './List';
import './style.css';

function ListsGrid() {

    const [lists, setLists] = useState([]);

    const buttonRef = useRef(null);

    function addList() {
        if (lists.length >= 8) {
            alert("Só é possível adicionar até 08 listas de tarefas!")
            return;
        }

        const listObject = {
            id: Date.now(),
            title: "Insira"

        }

        setLists([...lists, listObject]);
    }

    function deleteList(idToDelete) {
        setLists(lists.filter(list => list.id !== idToDelete));
    }
    useEffect(() => {
        if (!buttonRef.current) return;

        if (lists.length <= 7) {
            buttonRef.current.style.display = "inline-block";
        } else if (lists.length > 7) {
            buttonRef.current.style.display = "none";
        }
    }, [lists]);

    return (
        <main className="tasks-grid">
            {lists.map(list => (
                <List
                    key={list.id}
                    title={list.title}
                    deleteList={() => deleteList(list.id)}
                />
            ))}

            <button
                ref={buttonRef}
                className="add-list-button"
                onClick={() => addList()}>
                +
            </button>
        </main>
    );
}

export default ListsGrid;

