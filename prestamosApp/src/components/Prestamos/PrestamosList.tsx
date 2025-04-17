import { usePrestamos } from '../../hooks/usePrestamos';
import { formatUTCDate } from '../../utils/dateUtils';

export const PrestamosList = () => {
  const {
    prestamos,
    loading,
    error,
    devolverPrestamo,
    eliminarPrestamo,
    cargarActivos,
  } = usePrestamos();

  const handleDevolver = async (idPrestamo: string) => {
    if (window.confirm('¿Marcar este préstamo como devuelto?')) {
      try {
        await devolverPrestamo(idPrestamo);
        // Opcional: Recargar datos para asegurar consistencia
        await cargarActivos(); 
      } catch (error) {
        alert('Error al marcar como devuelto: ' + (error instanceof Error ? error.message : 'Error desconocido'));
      }
    }
  };

  if (loading) return <div className="spinner-border text-primary" />;
  if (error) return <div className="alert alert-danger">{error}</div>;

  return (
    <div className="mt-4">
      <div className="d-flex justify-content-between mb-3">
        <h2>Préstamos</h2>
        <button onClick={cargarActivos} className="btn btn-sm btn-outline-primary">
          Mostrar solo activos
        </button>
      </div>

      <div className="table-responsive">
        <table className="table table-hover">
          <thead className="table-light">
            <tr>
              <th>Libro</th>
              <th>Usuario</th>
              <th>Fecha Préstamo</th>
              <th>Fecha Devolución</th>
              <th>Estado</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {prestamos.map((prestamo) => (
              <tr key={prestamo.idPrestamo}>
                <td>{prestamo.tituloLibro}</td>
                <td>{`${prestamo.nombreUsuario}`}</td>
                <td>
                  {formatUTCDate(prestamo.fecha_Prestamo)}
                </td>
                <td>
                  {formatUTCDate(prestamo.fecha_Devolucion)}
                </td>
                <td>
                  <span
                    className={`badge ${
                      prestamo.estado === 'Activo' ? 'bg-success' : 'bg-secondary'
                    }`}
                  >
                    {prestamo.estado}
                  </span>
                </td>
                <td>
                  {prestamo.estado === 'Activo' && (
                    <button
                      onClick={() => handleDevolver(prestamo.idPrestamo)}
                      className="btn btn-sm btn-success me-2"
                      title="Marcar como devuelto"
                    >
                      <i className="bi bi-check-circle"></i>
                    </button>
                  )}
                  <button
                    onClick={() => eliminarPrestamo(prestamo.idPrestamo)}
                    className="btn btn-sm btn-danger"
                    title="Eliminar préstamo"
                  >
                    <i className="bi bi-trash"></i>
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};