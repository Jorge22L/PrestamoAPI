import { PrestamoForm } from "../components/Prestamos/PrestamoForm";
import { PrestamosList } from "../components/Prestamos/PrestamosList";


export const PrestamosPage = () => {
  return (
    <div className="container">
      <div className="row">
        <div className="col-lg-5 mb-4">
          <PrestamoForm />
        </div>
        <div className="col-lg-7">
          <PrestamosList />
        </div>
      </div>
    </div>
  );
};