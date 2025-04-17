import { apiClient } from "./apiClient";

export const prestamosApi = {
    listar: () => apiClient.get('/prestamos'),
    buscarPorId: (id: string) => apiClient.get(`/prestamos/${id}`),
    listarActivos: () => apiClient.get('/prestamos/activos'),
    agregar: (prestamo: 
        { 
            idLibro: string; 
            idUsuario: string;  
            fechaDevolucion: string | Date
        }) => apiClient.post('/prestamos', prestamo),
    actualizar: (id: string, prestamo: { idLibro?: string; idUsuario?: string; fecha_Prestamo?: string; fecha_Devolucion?: string; estado?: 'Activo'|'Devuelto' }) => 
        apiClient.put(`/prestamos/${id}`, prestamo),
    eliminar: (id: string) => apiClient.delete(`/prestamos/${id}`)
}
