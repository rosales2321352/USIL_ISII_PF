import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { useState } from 'react';
import Modal from 'react-modal';
import axios from 'axios';
import EditForm from './table/partials/edit.view';
import './table/table.css';

const UserData = ({ client }) => {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [selectedClient, setSelectedClient] = useState(null);

  const openModal = (client) => {
    setSelectedClient(client);
    setModalIsOpen(true);
  };

  const closeModal = () => {
    setSelectedClient(null);
    setModalIsOpen(false);
  };

  const handleSubmit = (id) => {
    const conf = window.confirm("¿Está seguro de eliminar este cliente?");
    if (conf) {
      axios
        .delete(process.env.REACT_APP_URL_CLIENT_LIST + id)
        .then((res) => {
          alert('Cliente fue eliminado.');
        })
        .catch((err) => console.log(err));
    }
  };

  const filteredClients = client.data.filter(curClient => curClient.name);

  return (
    <>
      {filteredClients.map((curClient) => {
        const { clientId, name, phoneNumber, email, company, status } = curClient;

        return (
          <tr key={clientId}>
            <td>{clientId}</td>
            <td>{name}</td>
            <td>{phoneNumber}</td>
            <td>{email}</td>
            <td>{company.address}</td> { }
            <td>{company.name}</td> { }
            <td>{status.name}</td> { }
            <td>
              <button onClick={() => openModal(curClient)} className='btn_edi'>
                <EditIcon/>
              </button>
              <button onClick={() => handleSubmit(curClient.id)} className='btn_de'>
                <DeleteIcon />
              </button>
            </td>
          </tr>
        );
      })}

      <tr style={{display:"none"}}>
              <td>
                {selectedClient &&
              <Modal 
                  isOpen={modalIsOpen}
                  onRequestClose={closeModal}
                  contentLabel="Edit Client Modal"
              >
                <EditForm client={selectedClient} closeModal={closeModal} />
              </Modal> }
              </td>
      </tr>
      
    </>
  );
};

export default UserData;