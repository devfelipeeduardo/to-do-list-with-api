import "./style.css"

function Nav( {search, setSearch} ) {



    return (
        <nav className="nav">
            <h1 className="title">Shorts</h1>
            <div className="search-container">
                <input
                className="search-input"
                type="text-box"
                placeholder="Buscar lista..."
                value={search}
                onChange={(e) => setSearch(e.target.value)}
                />
                <button className="search-button">Pesquisar</button>
            </div>
        </nav>
    );
}

export default Nav;

