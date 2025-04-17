import { Link } from "react-router-dom";

export const HomePage = () => {
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
        </div>
    )
}