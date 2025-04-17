import { apiClient } from "./apiClient";

export const librosApi = {
    listar: () => apiClient.get('/libros'),
    buscarPorId: (id: string) => apiClient.get(`/libros/${id}`),
    agregar: (libro: { titulo: string; autor: string }) => apiClient.post('/libros', libro),
    actualizar: (id: string, libro: { titulo?: string; autor?: string }) => apiClient.put(`/libros/${id}`, libro),
    eliminar: (id: string) => apiClient.delete(`/libros/${id}`)
}