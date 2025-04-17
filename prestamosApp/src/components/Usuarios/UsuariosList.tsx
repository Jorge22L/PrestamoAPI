import { useState } from "react";
import { useUsuarios } from "../../hooks/useUsuarios";
import { Usuario } from "../../types/types";
import { UsuarioEditModal } from "./UsuarioEditModal";

export const UsuariosList = () => {
    const { usuarios, loading, error, eliminarUsuario, refetch } = useUsuarios();
    const [editUsuario, setEditUsuario] = useState<Usuario | null>(null)
   

    const handleEdit = (usuario: Usuario) => {
        setEditUsuario(usuario)
    }


    if (loading) return <div className="spinner-border text-primary"></div>;
    if (error) return <div className="alert alert-danger">{error}</div>

    return (
        <div className="mt-4">
            <h2 className="mb-3">Listado de Usuarios</h2>

            <div className="table-responsive">
                <table className="table table-striped table-hover">
                    <thead className="table-dark">
                        <tr>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Email</th>
                            <th>Teléfono</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {usuarios.map(usuario => (
                            <tr key={usuario.idUsuario}>
                                <td>{usuario.nombre}</td>
                                <td>{usuario.apellido}</td>
                                <td>{usuario.email}</td>
                                <td>{usuario.telefono || '-'}</td>
                                <td>
                                    <button
                                        onClick={() => handleEdit(usuario)}
                                        className="btn btn-sm btn-outline-primary me-2">
                                        <i className="bi bi-pencil"></i>
                                    </button>

                                    <button
                                        onClick={() => eliminarUsuario(usuario.idUsuario)}
                                        className="btn btn-sm btn-outline-danger"
                                    >
                                        <i className="bi bi-trash"></i>
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>

                {editUsuario && (
                    <UsuarioEditModal
                        usuario={editUsuario!}
                        onClose={() => setEditUsuario(null)}
                        onSave={refetch}
                    />
                )}
            </div>
        </div>
    )
}