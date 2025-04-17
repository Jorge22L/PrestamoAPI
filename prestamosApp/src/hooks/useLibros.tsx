import { useEffect, useState } from "react";
import { librosApi } from "../api/librosApi";
import { Libro } from "../types/types";

export const useLibros = () => {
    const [libros, setLibros] = useState<Libro[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const fetchLibros = async () => {
        try {
            const response = await librosApi.listar()
            setLibros(response.data);
        } catch (error) {
            setError("Error cargando libros");
            console.error("Error cargando libros:", error);
        }
        finally {
            setLoading(false);
        }
    };
    useEffect(() => {
        fetchLibros();
    }, [])

    return { libros, loading, error, refetch: fetchLibros };
}