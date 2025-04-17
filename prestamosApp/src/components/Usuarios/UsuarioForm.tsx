import { Usuario } from "../../types/types";
import { useUsuarios } from "../../hooks/useUsuarios";
import { FormEvent, useState } from "react";

type Props = {
    usuario?: Usuario;
    onSuccess?: () => void;
}

export const UsuarioForm = ({ usuario, onSuccess }: Props) => {
    const { agregarUsuario, actualizarUsuario } = useUsuarios()
    const [form, setForm] = useState<Partial<Usuario>>({
        nombre: usuario?.nombre || '',
        apellido: usuario?.apellido || '',
        email: usuario?.email || '',
        telefono: usuario?.telefono || '',
        idUsuario: usuario?.idUsuario || ''
    })

    const [errors, setErrors] = useState<Record<string, string>>({})

    const validate = () => {
        const newErrors: Record<string, string> = {}
        if (!form.nombre?.trim()) newErrors.nombre = 'Nombre es requerido'
        if (!form.apellido?.trim()) newErrors.apellido = 'Apellido es requerido'
        else if (!/^\S+@\S+\.\S+$/.test(form.email || '')) newErrors.email = 'Email inválido';
        return newErrors
    }

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        const validationErrors = validate()
        if (Object.keys(validationErrors).length > 0) {
            setErrors(validationErrors)
            return
        }

        try {
            if (usuario?.idUsuario) {
                await actualizarUsuario(usuario.idUsuario, form)
            }
            else {
                await agregarUsuario({
                    nombre: form.nombre || '',
                    apellido: form.apellido || '',
                    email: form.email || '',
                    telefono: form.telefono || ''
                })
            }

            setForm({ nombre: '', apellido: '', email: '', telefono: '' })
            onSuccess?.()
        }
        catch (error) {
            console.error('Error al guardar usuario:', error);
        }
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <input
                        type="text"
                        name="nombre"
                        className={`form-control ${errors.nombre ? 'is-invalid' : ''}`}
                        placeholder="Nombre"
                        value={form.nombre}
                        onChange={(e) => setForm({ ...form, nombre: e.target.value })}
                    />
                    {errors.nombre && <div className="invalid-feedback">{errors.nombre}</div>}
                </div>
                <div className="mb-3">
                    <input
                        type="text"
                        name="apellido"
                        placeholder="Apellido"
                        className={`form-control ${errors.apellido ? 'is-invalid' : ''}`}
                        value={form.apellido}
                        onChange={(e) => setForm({ ...form, apellido: e.target.value })}
                    />
                    {errors.apellido && <div className="invalid-feedback">{errors.apellido}</div>}
                </div>
                <div className="mb-3">
                    <input
                        type="email"
                        name="correo"
                        placeholder="correo@mail.com"
                        className={`form-control ${errors.email ? 'is-invalid' : ''}`}
                        value={form.email}
                        onChange={(e) => setForm({ ...form, email: e.target.value })}
                    />
                    {errors.email && <div className="invalid-feedback">{errors.email}</div>}
                </div>
                <div className="mb-3">
                    <input
                        type="tel"
                        name="telefono"
                        placeholder="88996633"
                        className={`form-control ${errors.telefono ? 'is-invalid' : ''}`}
                        value={form.telefono}
                        onChange={(e) => setForm({ ...form, telefono: e.target.value })}
                    />
                    {errors.telefono && <div className="invalid-feedback">{errors.telefono}</div>}
                </div>

                <div className="d-grid gap-2">
                    <button type="submit" className="btn btn-primary">
                        {usuario?.idUsuario ? 'Actualizar Usuario' : 'Crear Usuario'}
                    </button>
                </div>
            </form>
        </>
    )
}