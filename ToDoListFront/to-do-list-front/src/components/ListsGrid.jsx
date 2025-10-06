import { useEffect, 
        //  useState,
         useRef } from 'react';
import List from './List';
import './style.css';

function ListsGrid({lists, setLists}) {
    
    const buttonRef = useRef(null);

    function addList() {
        if (lists.length >= 8) {
            alert("Só é possível adicionar até 08 listas de tarefas!")
            return;
        }

        const listObject = {
            id: Date.now(),
            title: "Título"

        }

        setLists([...lists, listObject]);
    }

    function deleteList(idToDelete) {
        setLists(lists.filter(list => list.id !== idToDelete));
    }

    function updateListTitle(id, newTitle) {
        setLists(prevLists =>
            prevLists.map(list =>
                list.id === id ? { ...list, title: newTitle} : list
            )
        );
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
                    id={list.id}
                    title={list.title}
                    updateListTitle={updateListTitle}
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

