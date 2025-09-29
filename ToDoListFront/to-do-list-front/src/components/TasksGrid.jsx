import List from './List';
import './style.css';

function TasksGrid() {

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

export default TasksGrid;

