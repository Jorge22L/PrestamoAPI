import { UsuarioForm } from "../components/Usuarios/UsuarioForm";
import { UsuariosList } from "../components/Usuarios/UsuariosList";

export const UsuariosPage = () => {
    return (
        <div className="container py-4">
            <div className="row">
                <div className="col-md-5 mb-4 mb-md-0">
                    <div className="card shadow-sm">
                        <div className="card-body">
                            <h3 className="card-title mb-4">
                                {location.pathname.includes('edit') ? 'Editar' : 'Nuevo'} Usuario
                            </h3>
                            <UsuarioForm />
                        </div>
                    </div>
                </div>
                <div className="col-md-7">
                    <div className="card shadow-sm">
                        <div className="card-body">
                            <UsuariosList />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}