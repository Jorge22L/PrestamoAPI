import React, { useState } from "react";
import { librosApi } from "../../api/librosApi";
import { Libro } from "../../types/types";

type LibroFormProps = {
    initialData?: Partial<Libro>;
    onSuccess?: () => void;
}

export const LibrosForm = ({ initialData, onSuccess }: LibroFormProps) => {
    const [form, setForm] = useState<{
        idLibro: string
        titulo: string;
        autor: string;
        disponible: boolean;
    }>({
        titulo: initialData?.titulo || "",
        autor: initialData?.autor || "",
        disponible: initialData?.disponible ?? true,
        idLibro: initialData?.idLibro || ""
    })

    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true)
        try {
            if (form.idLibro) {
                await librosApi.actualizar(form.idLibro, form)
                
            } else {
                await librosApi.agregar(form);
                
            }
            onSuccess?.()
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="card mt-4">
            <div className="card-body">
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Título del libro"
                            value={form.titulo}
                            onChange={(e) => setForm({ ...form, titulo: e.target.value })}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Autor del libro"
                            value={form.autor}
                            onChange={(e) => setForm({ ...form, autor: e.target.value })}
                            required
                        />
                    </div>
                    <div className="mb-3 form-check">
                        <input type="checkbox"
                            className="form-check-input"
                            checked={form.disponible}
                            onChange={(e) => setForm({ ...form, disponible: e.target.checked })}
                            id="disponible"
                         />
                        <label className="form-check-label" htmlFor="disponible">
                            Disponible
                        </label>
                    </div>

                    <button className="btn btn-primary" type="submit" disabled={loading}>
                        {loading ? "Guardando..." : 'Guardar Libro'}
                    </button>
                </form>
            </div>
        </div>
    )
}