import { Link } from "react-router-dom";

export const NavBar = () => {
    return (
        <nav className="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Biblioteca App</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                data-bs-target="#navbarNav">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav me-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="/prestamos">Préstamos</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/libros">Libros</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/usuarios">Usuarios</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}