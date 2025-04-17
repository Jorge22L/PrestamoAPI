import { Modal } from "react-bootstrap";
import { LibrosForm } from "./LibrosForm";
import { Libro } from "../../types/types";

type Props = {
    libro: Libro;
    onClose: () => void;
    onSave: () => void;
}

export const LibroEditModal = ({ libro, onClose, onSave }: Props) => {
    return (
        <Modal show={true} onHide={onClose}>
            <Modal.Header closeButton>
                <Modal.Title>Editar Libro</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <LibrosForm 
                    initialData={{...libro}}
                    onSuccess = {() => {
                        onSave();
                        onClose();
                    }} 
                    />
            </Modal.Body>

        </Modal>
    )
}