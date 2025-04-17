import { useState } from "react";
import { useLibros } from "../../hooks/useLibros";
import { usePrestamos } from "../../hooks/usePrestamos";
import { useUsuarios } from "../../hooks/useUsuarios";
import { format } from "date-fns";

interface FormState {
    idLibro: string,
    idUsuario: string,
    fechaDevolucion: string
}

export const PrestamoForm = () => {
  const { crearPrestamo } = usePrestamos();
  const { libros } = useLibros();
  const { usuarios } = useUsuarios();

  const [form, setForm] = useState<FormState>({
    idLibro: '',
    idUsuario: '',
    fechaDevolucion: format(new Date(Date.now() + 7 * 24 * 60 * 60 * 1000), 'yyyy-MM-dd'), // +7 días
  });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    console.log("Valores a enviar: " ,{
        idLibro: form.idLibro,
        idUsuario: form.idUsuario,
        fechaDevolucion: form.fechaDevolucion
    })
    try {
      await crearPrestamo({
        idLibro: form.idLibro,
        idUsuario: form.idUsuario,
        fechaDevolucion: form.fechaDevolucion
      })
      alert('Préstamo creado exitosamente!');
    } catch (error) {
      if (error instanceof Error) {
        alert(error.message);
      } else {
        alert('Ocurrió un error inesperado.');
      }
    }
  };

  return (
    <div className="card shadow-sm">
      <div className="card-body">
        <h5 className="card-title">Nuevo Préstamo</h5>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label className="form-label">Libro</label>
            <select
              className="form-select"
              value={form.idLibro}
              onChange={(e) => setForm({ ...form, idLibro: e.target.value })}
              required
            >
              <option value="">Seleccionar libro</option>
              {libros
                .filter((libro) => libro.disponible)
                .map((libro) => (
                  <option key={libro.idLibro} value={libro.idLibro}>
                    {libro.titulo} - {libro.autor}
                  </option>
                ))}
            </select>
          </div>

          <div className="mb-3">
            <label className="form-label">Usuario</label>
            <select
              className="form-select"
              value={form.idUsuario}
              onChange={(e) => setForm({ ...form, idUsuario: e.target.value })}
              required
            >
              <option value="">Seleccionar usuario</option>
              {usuarios.map((usuario) => (
                <option key={usuario.idUsuario} value={usuario.idUsuario}>
                  {usuario.nombre} {usuario.apellido}
                </option>
              ))}
            </select>
          </div>

          <div className="mb-3">
            <label className="form-label">Fecha de Devolución</label>
            <input
              type="date"
              className="form-control"
              value={form.fechaDevolucion}
              onChange={(e) => setForm({ ...form, fechaDevolucion: e.target.value })}
              min={format(new Date(), 'yyyy-MM-dd')}
              required
            />
          </div>

          <button type="submit" className="btn btn-primary">
            Registrar Préstamo
          </button>
        </form>
      </div>
    </div>
  );
};