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
    usuarioNombre: string;
    usuarioApellido: string;
    fechaPrestamo: string;
    fechaDevolucion: string;
    estado: 'Activo' | 'Devuelto';
}
