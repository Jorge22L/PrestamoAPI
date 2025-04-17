export interface Libro {
    idLibro: string;
    titulo: string;
    autor: string;
    disponible: boolean;
}

export interface Usuario {
    idUsuario: string;
    nombre: string;
    apellido: string;
    email: string;
    telefono: string;
}

export interface Prestamo {
    idPrestamo: string;
    idLibro: string;
    tituloLibro?: string;
    idUsuario: string;
    nombreUsuario: string;
    usuarioApellido: string;
    fecha_Prestamo: string;
    fecha_Devolucion: string;
    estado: 'Activo' | 'Devuelto';
}
