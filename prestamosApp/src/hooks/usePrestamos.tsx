import { useState, useEffect } from 'react';
import { prestamosApi } from '../api/prestamosApi';
import { Prestamo } from '../types/types';

export const usePrestamos = () => {
  const [prestamos, setPrestamos] = useState<Prestamo[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Cargar todos los préstamos
  const cargarPrestamos = async () => {
    try {
      setLoading(true);
      const response = await prestamosApi.listar();
      setPrestamos(response.data);
    } catch (err) {
      setError('Error al cargar préstamos');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  // Cargar préstamos activos
  const cargarActivos = async () => {
    try {
      setLoading(true);
      const response = await prestamosApi.listarActivos();
      setPrestamos(response.data);
    } catch (err) {
      setError('Error al cargar préstamos activos');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  // Crear préstamo
  const crearPrestamo = async (prestamo: {
    idLibro: string;
    idUsuario: string;
    fechaDevolucion: string;
  }) => {
    try {
      const response = await prestamosApi.agregar(prestamo);
      setPrestamos([...prestamos, response.data]);
      return response.data;
    } catch (err) {
      throw new Error('Error al crear préstamo');
    }
  };

  // Actualizar préstamo (incluye devolución)
  const actualizarPrestamo = async (
    idPrestamo: string,
    datos: {
      idPrestamo: string,
      fecha_Devolucion: string,
      estado?: 'Activo' | 'Devuelto'
    }
  ) => {
    try {
      const response = await prestamosApi.actualizar(idPrestamo, {
        fecha_Devolucion: datos.fecha_Devolucion,
        estado: datos.estado
      });
      setPrestamos(
        prestamos.map((p) =>
          p.idPrestamo === idPrestamo ?
            {
              ...p,
              fecha_Devolucion: datos.fecha_Devolucion,
              estado: datos.estado || p.estado
            }
            : p
        )
      );
      return response.data;
    } catch (err) {
      throw new Error('Error al actualizar préstamo');
    }
  };

  const devolverPrestamo = async (idPrestamo: string) => {
    const updateData = {
      idPrestamo: idPrestamo,
      fecha_Devolucion: new Date().toISOString(),
      estado: 'Devuelto' as const
    };
  
    const response = await prestamosApi.actualizar(idPrestamo, updateData);
    return response.data; // Asegúrate que la API devuelve el préstamo actualizado
  };

  // Eliminar préstamo
  const eliminarPrestamo = async (idPrestamo: string) => {
    try {
      await prestamosApi.eliminar(idPrestamo);
      setPrestamos(prestamos.filter((p) => p.idPrestamo !== idPrestamo));
    } catch (err) {
      throw new Error('Error al eliminar préstamo');
    }
  };

  // Cargar datos iniciales
  useEffect(() => {
    cargarPrestamos();
  }, []);

  return {
    prestamos,
    loading,
    error,
    cargarPrestamos,
    cargarActivos,
    crearPrestamo,
    actualizarPrestamo,
    devolverPrestamo,
    eliminarPrestamo,
  };
};