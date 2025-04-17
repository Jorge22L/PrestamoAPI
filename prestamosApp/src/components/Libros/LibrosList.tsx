import { useState } from "react";
import { useLibros } from "../../hooks/useLibros";
import { Libro } from "../../types/types";
import { librosApi } from "../../api/librosApi";
import { LibroEditModal } from "./LibroEditModal";

export const LibrosList = () => {
    const { libros, loading, error, refetch } = useLibros();
    const [ selectedLibro, setSelectedLibro ] = useState<Libro | null>(null);

    const handleDelete = async(idLibro: string) => {
        if(window.confirm("¿Estás seguro de eliminar este libro?")) {
            await librosApi.eliminar(idLibro);
            refetch();
            alert("Libro eliminado correctamente");
        }
    }

    if (loading) {
        return <div className="text-center mt-4">
            <div className="spinner-border text-primary" role="status">
                <span className="visually-hidden">Cargando...</span>
            </div>
            <p>Cargando libros...</p>
        </div>;
    }

    if (error) {
        return <div className="alert alert-danger mt-4">{error}</div>;
    }

    return (
        <div className="mt-4">
            <h2>Listado de Libros</h2>
            <table className="table table-striped table-responsive">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    {libros.map(libro => (
                        <tr key={libro.idLibro}>
                            <td>{libro.idLibro}</td>
                            <td>{libro.titulo}</td>
                            <td>{libro.autor}</td>
                            <td>
                                <span className={`badge ${libro.disponible ? 'bg-success' : 'bg-warning'}`} >
                                    {libro.disponible ? 'Disponible' : 'No disponible'}
                                </span>
                            </td>
                            <td>
                                <button onClick={() => setSelectedLibro(libro)}
                                    className="btn btn-sm btn-outline-primary me-2"
                                    >
                                        Editar
                                </button>
                                <button className="btn btn-sm btn-outline-danger"
                                    onClick={() => handleDelete(libro.idLibro)}>
                                        Eliminar
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {selectedLibro && (
                <LibroEditModal 
                    libro={selectedLibro!} 
                    onClose={() => setSelectedLibro(null)} 
                    onSave={refetch} 
                    />
            )}
        </div>

    )
}