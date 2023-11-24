import * as React from 'react';
import Modal from 'react-modal';
import UserData from '../UserData';
import AddForm from './partials/add.view';
import AddIcon from '@mui/icons-material/Add';
import "./table.css";

export default function Tableview({data}) 
{
    const [modalIsOpen, setModalIsOpen] = React.useState(false);
    
    const openModal = () => {
        setModalIsOpen(true);
    };

    const closeModal = () => {
        setModalIsOpen(false);
    };

    return <>
    <div>
        <div className='text-end'><button onClick={openModal} className='btn btn-primary'> <AddIcon/> </button></div>
    
        <table className='table'>
                <thead>
                    <tr>
                            <th className='id'>ID</th>
                            <th className='nombre'>Nombre</th>
                            <th>Numero</th>
                            <th >Email</th>
                            <th className='address'>Direccion</th>
                            <th >Empresa</th>
                            <th >Estado</th>
                            <th className='acc'>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                        <UserData client={data}/>
                </tbody>
        </table>
        <Modal
            isOpen={modalIsOpen}
            onRequestClose={closeModal}
            contentLabel="Edit Client Modal"
        >
        <AddForm closeModal={closeModal} />
        </Modal>
    </div>
        
    
    </>
}
