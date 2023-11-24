import * as React from 'react';
import Modal from 'react-modal';
import UserData from '../UserData';
import './table.css';

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
        <table className='table'>
                <thead className='thead'>
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
        </Modal>
    </div>
        
    
    </>
}
