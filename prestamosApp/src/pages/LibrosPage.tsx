import { LibrosForm } from "../components/Libros/LibrosForm"
import { LibrosList } from "../components/Libros/LibrosList"

export const LibrosPage = () => {
    return (
    <div className="container mt-4">
        <div className="row">
            <div className="col-md-4">
                <div className="card mt-4">
                    <div className="card-body">
                        <h5>Agregar Libro</h5>
                        <LibrosForm />
                    </div>
                </div>
            </div>
            <div className="col-md-8">
                <LibrosList />
            </div>
        </div>
    </div>
    )
}