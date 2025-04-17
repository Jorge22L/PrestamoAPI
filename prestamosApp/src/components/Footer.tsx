export const Footer = () => {
    return (
      <footer className="bg-dark text-white py-4 mt-5">
        <div className="container text-center">
          <p className="mb-0">
            © {new Date().getFullYear()} Biblioteca App - Todos los derechos reservados
          </p>
        </div>
      </footer>
    );
  };