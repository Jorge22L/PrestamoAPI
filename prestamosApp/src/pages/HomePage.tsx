import { Link } from "react-router-dom";
import { useLibros } from "../hooks/useLibros";
import { useUsuarios } from "../hooks/useUsuarios";

export const HomePage = () => {
    const { libros } = useLibros()
    const { usuarios } = useUsuarios();
    return (
        <div className="container py-5">
            <div className="row">
                <div className="col-md-8 mx-auto text-center">
                    <h1 className="display-4 mb-4">
                        <i className="bi bi-book text-primary"></i> Sistema de Préstamos
                    </h1>
                    <p className="lead text-muted mb-5">Gestiona tu biblioteca con el sistema de préstamos.</p>
                </div>
            </div>

            <div className="row g-4">
                {/* Card Libros */}
                <div className="col-md-4">
                    <div className="card h-100 border-0 shadow-sm">
                        <div className="card-body text-center">
                            <h2 className="text-primary">
                                <i className="bi bi-book"></i> {libros.length}
                            </h2>
                            <h5 className="card-title">Libros disponibles</h5>
                            <Link to="/libros" className="btn btn-outline-primary mt-3">Gestionar Libros</Link>
                        </div>
                    </div>
                </div>
                {/* Card Usuarios */}
                <div className="col-md-4">
                    <div className="card h-100 border-0 shadow-sm">
                        <div className="card-body text-center">
                            <h2 className="text-primary">
                                <i className="bi bi-people"></i> {usuarios.length}
                            </h2>
                            <h5 className="card-title">Usuarios registrados</h5>
                            <Link to="/usuarios" className="btn btn-outline-primary mt-3">Gestionar Usuarios</Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}