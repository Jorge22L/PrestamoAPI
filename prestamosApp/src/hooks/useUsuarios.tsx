import { useEffect, useState } from "react";
import { usuariosApi } from "../api/usuariosApi";
import { Usuario } from "../types/types";

export const useUsuarios = () => {
    const [usuarios, setUsuarios] = useState<Usuario[]>([])
    const [loading, setLoading] = useState(true)
    const [error, setError] = useState<string | null>(null)

    const fetchUsuarios = async () => {
        try {
            const response = await usuariosApi.listar()
            setUsuarios(response.data)
        }
        catch (err) {
            setError('Error al cargar usuarios')
            console.error(err)
        }
        finally {
            setLoading(false)
        }
    }

    const agregarUsuario = async (usuario: Omit<Usuario, 'idUsuario'>) => {
        try {
            const response = await usuariosApi.agregar(usuario)
            setUsuarios([...usuarios, response.data])
        }
        catch (err) {
            setError('Error al crear usuario')
            throw err
        }
    }

    const actualizarUsuario = async (idUsuario: string, usuario: Partial<Usuario>) => {
        try {
            const response = await usuariosApi.actualizar(idUsuario, usuario as { email: string; nombre?: string; apellido?: string; telefono?: string });
            setUsuarios(usuarios.map(u => u.idUsuario === idUsuario ? response.data : u))
        }
        catch (err) {
            setError("Error al actualizar usuario")
            throw err;
        }
    }

    const eliminarUsuario = async (idUsuario: string) => {
        try {
            if (window.confirm("¿Estás seguro de eliminar este usuario?")) {
                await usuariosApi.eliminar(idUsuario)
                setUsuarios(usuarios.filter(u => u.idUsuario !== idUsuario))
                alert("Usuario eliminado correctamente")
            }

        }
        catch (err) {
            setError('Error al eliminar usuario')
            throw err;
        }
    }

    useEffect(() => {
        fetchUsuarios()
    }, [])

    return { usuarios, loading, error, agregarUsuario, actualizarUsuario, eliminarUsuario, refetch: fetchUsuarios }
}