import axios from 'axios';
import React, { useState} from 'react';
import { useNavigate } from 'react-router-dom';

const EditForm = ({ client, closeModal }) => {
  const [data, setData] = useState(client);
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();

    if (data) {
      let clientformat = {
          personID: data.clientId,
          clientStatusID: data.clientStatusID,
          name: data.name,
          email: data.email,
          companyID: data.companyname,
          
      }
    }
    // public int PersonID { get; set; }
    //     public int ClientStatusID { get; set; }
    //     public string Name { get; set; } = null!;
    //     public string? Email { get; set; } = null!;
    //     public string PhoneNumber { get; set; } = null!;
    //     public string WhatsappID { get; set; } = null!;
    //     public int? CompanyID { get; set; }
    // // const apiUrl = process.env.REACT_APP_URL_CLIENT_EDIT + client.id;
    // console.log('API URL:', apiUrl);
    // console.log('Data:', data);

    // axios
    // .put(apiUrl, data)
    //   .then((res) => {
    //     alert("Cliente actualizado satisfactoriamente.");
    //     navigate('client');
    //     closeModal();
    //   })
    //   .catch((err) => {
    //     console.error("Error al actualizar el cliente:", err);
    //   });
    console.log(data)
  };

  // Función para determinar si un campo debe mostrarse o no en el formulario
  const shouldDisplayField = (fieldName) => {
    const nonEditableFields = ['clientId', 'whatsappData', 'phoneNumber'];
    return !nonEditableFields.includes(fieldName);
  };

  return (
    <form onSubmit={handleSubmit}>
      {Object.keys(data).map((key) => (
        // Verifica si el campo debe mostrarse
        shouldDisplayField(key) && (
          <div key={key}>
            <label htmlFor={key}>{key}</label>
            {typeof data[key] === 'object' ? (
              // Si el valor es un objeto, muestra campos anidados
              Object.keys(data[key]).map((nestedKey) => (
                <div key={nestedKey}>
                  <label htmlFor={`${key}.${nestedKey}`}>{nestedKey}</label>
                  <input
                    type='text'
                    name={`${key}.${nestedKey}`}
                    value={data[key][nestedKey]}
                    className='form-control'
                    onChange={(e) =>
                      setData({
                        ...data,
                        [key]: {
                          ...data[key],
                          [nestedKey]: e.target.value,
                        },
                      })
                    }
                  />
                </div>
              ))
            ) : (
              // Si el valor no es un objeto, muestra un campo de entrada regular
              <input
                type='text'
                name={key}
                value={data[key]}
                className='form-control'
                onChange={(e) => setData({ ...data, [key]: e.target.value })}
              />
            )}
          </div>
        )
      ))}
      <br />

      <button className='btn btn-info'>Update</button>
    </form>
  );
};

export default EditForm;