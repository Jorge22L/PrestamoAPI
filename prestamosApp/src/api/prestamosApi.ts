import { apiClient } from "./apiClient";

export const prestamosApi = {
    listar: () => apiClient.get('/prestamos'),
    buscarPorId: (id: string) => apiClient.get(`/prestamos/${id}`),
    listarActivos: () => apiClient.get('/prestamos/activos'),
    agregar: (prestamo: 
        { 
            libroId: string; 
            usuarioId: string;  
            fechaDevolucion: string 
        }) => apiClient.post('/prestamos', prestamo),
    actualizar: (id: string, prestamo: { libroId?: string; usuarioId?: string; fechaPrestamo?: string; fechaDevolucion?: string }) => 
        apiClient.put(`/prestamos/${id}`, prestamo),
    eliminar: (id: string) => apiClient.delete(`/prestamos/${id}`)
}
