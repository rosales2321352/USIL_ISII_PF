import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import "./modal.css";

const AddForm = ({ closeModal }) => {
  const [inputData, setInputData] = useState({
    name: '',
    phoneNumber: '',
    email: '',
    company: {
      company_address: '',
      company_name: '',
    },
    status: {
      clientStatusID: 1,
      name: 'Sin Agregar',
    },
  });
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();

    axios
      .post(process.env.REACT_APP_URL_CLIENT_CREATE, inputData)
      .then((res) => {
        alert("Cliente Agregado Satisfactoriamente.");
        navigate('client');
        closeModal();
      })
      .catch((err) => {
        console.error("Error al agregar el cliente:", err);
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="name">Name:</label>
        <input
          value={inputData.name}
          type='text'
          name='name'
          className='form-control'
          onChange={(e) => setInputData({ ...inputData, name: e.target.value })}
        />
      </div>
      <div>
        <label htmlFor="phoneNumber">Phone Number:</label>
        <input
          value={inputData.phoneNumber}
          type='text'
          name='phoneNumber'
          className='form-control'
          onChange={(e) => setInputData({ ...inputData, phoneNumber: e.target.value })}
        />
      </div>
      <div>
        <label htmlFor="email">Email:</label>
        <input
          value={inputData.email}
          type='text'
          name='email'
          className='form-control'
          onChange={(e) => setInputData({ ...inputData, email: e.target.value })}
        />
      </div>
      <div>
        <label htmlFor="company.name">Company Name:</label>
        <input
          value={inputData.company.company_name}
          type='text'
          name='company_name'
          className='form-control'
          onChange={(e) => setInputData({ ...inputData, company: { ...inputData.company, company_name: e.target.value } })}
        />
      </div>
      <div>
        <label htmlFor="company.address">Company Address:</label>
        <input
          value={inputData.company.company_address}
          type='text'
          name='company_address'
          className='form-control'
          onChange={(e) => setInputData({ ...inputData, company: { ...inputData.company, company_address: e.target.value } })}
        />
      </div>
      <br />

      <button type='submit' className='btn btn-info'>
        Submit
      </button>

    </form>
  );
};

export default AddForm;
