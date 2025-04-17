import { apiClient } from "./apiClient";

export const usuariosApi = {
    listar: () => apiClient.get('/usuarios'),
    buscarPorId: (id: string) => apiClient.get(`/usuarios/${id}`),
    agregar: (usuario: { nombre: string; apellido: string; email: string; telefono?: string }) => 
        apiClient.post('/usuarios', usuario),
    actualizar: (id: string, usuario: { nombre?: string; apellido?: string; email: string; telefono?: string }) => 
        apiClient.put(`/usuarios/${id}`, usuario),
    eliminar: (id: string) => apiClient.delete(`/usuarios/${id}`)
}
