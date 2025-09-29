import "./style.css"

function Nav() {

    return (
        <nav className="nav">
            <h1 className="title">Shorts</h1>
            <div className="search-container">
                <input className="search-input" type="text-box" />
                <button className="search-button">Pesquisar</button>
            </div>
        </nav>
    );
}

export default Nav;

