import { Modal } from 'react-bootstrap';
import { Usuario } from '../../types/types';
import { UsuarioForm } from './UsuarioForm';
type Props = {
    usuario: Usuario;
    onClose: () => void;
    onSave: () => void;
}

export const UsuarioEditModal = ({ usuario, onClose, onSave }: Props) => {
    return (
        <Modal show={true} onHide={onClose}>
            <Modal.Header closeButton>
                <Modal.Title>Editar Libro</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <UsuarioForm 
                    usuario={{...usuario}}
                    onSuccess = {() => {
                        onSave();
                        onClose();
                    }} 
                    />
            </Modal.Body>

        </Modal>
    )
}