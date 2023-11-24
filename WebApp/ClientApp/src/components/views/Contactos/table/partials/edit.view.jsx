import React, { useContext, useState} from 'react';
import { submitApi } from '../../../../../hooks/useApi';
import CompanySelector from './companyselector';
import StatusSelector from './statusselector';
import './modal.css';
import ContactosContext from '../../../../../context/Contactos/contactos.context';

const EditForm = ({ client, closeModal }) => {
  const {reload, setReload} = useContext(ContactosContext);
  const [data, setData] = useState(client);
  const handleSubmit = (event) => {
    event.preventDefault();

    if (data) {
      let clientformat = {
          personID: data.clientId,
          phoneNumber: data.phoneNumber,
          clientStatusID: data.status.clientStatusID,
          name: data.name,
          email: data.email,
          companyID: data.company.companyID,
          whatsappID : data.whatsappData.whatsappID
      }
      
      console.log(clientformat);

      submitApi ({
        url: process.env.REACT_APP_URL_CLIENT_EDIT,
        options:{
          method:"POST",
          body: JSON.stringify(clientformat)
        }
      })
      .then(()=>{
          setReload(!reload);
      })
      .finally(()=> {
        closeModal();
      })
    }
    console.log(data)
  };

  // Función para determinar si un campo debe mostrarse o no en el formulario
  const shouldDisplayField = (fieldName) => {
    const nonEditableFields = ['clientId', 'whatsappData', 'phoneNumber'];
    return !nonEditableFields.includes(fieldName);
  };

  return (
    <form onSubmit={handleSubmit} >
      <div className='container'>
          <div class="text">
            Editar Contacto
          </div>
          <div className='modal-container'>
            <label htmlFor="name">Name:</label>
            <input
              value={data.name}
              type='text'
              name='name'
              className='form-control'
              onChange={(e) => setData({ ...data, name: e.target.value })}
            />
        </div>
        <div className='modal-container'>
          <label htmlFor="phoneNumber">Numero:</label>
          <input
            value={data.phoneNumber}
            type='text'
            name='phoneNumber'
            className='form-control'
            readOnly={true}
            onChange={(e) => setData({ ...data, phoneNumber: e.target.value })}
          />
        </div>
        <div className='modal-container'>
          <label htmlFor="email">Email:</label>
          <input
            value={data.email}
            type='text'
            name='email'
            className='form-control'
            onChange={(e) => setData({ ...data, email: e.target.value })}
          />
        </div>

        <div className='modal-container'>
          <label htmlFor="company.name">Empresa:</label>
            <CompanySelector data_={{data, setData}}/>
        </div>

        <div className='modal-container'>
          <label htmlFor="status.name">Estado:</label>
            <StatusSelector data_={{data, setData}}/>
        </div>
        
        <button type='submit' className='btn-info'>
          Submit
        </button>

      </div>
      
    </form>
  );
};

export default EditForm;