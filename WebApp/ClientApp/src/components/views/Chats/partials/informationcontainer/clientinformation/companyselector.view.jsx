import * as React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import useApi from '../../../../../../hooks/useApi';


export default function CompanySelectorView({companyID,form,onBlur,setClientFormPrevious}){

  const ClientContext_ = React.useContext(ClientContext);

  const {clientForm,setClientForm} = form;

  const companies = useApi({
    url: process.env.REACT_APP_URL_COMPANY_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  })

  const [age, setAge] = React.useState('');

  const handleChange = (event) => {
    setClientFormPrevious(clientForm);
    setClientForm({
      ...clientForm,
      companyID: parseInt(event.target.selectedOptions[0].value)
    })
  };
  

  return(
    <select className='form-select' onBlur={onBlur} style={{fontSize:"14px",textAlign:"right",display:"inline-block"}} name="companyID"  value={clientForm.companyID} onChange={handleChange}>
      <option value=""></option>
      {companies.data && Array.isArray(companies.data) && companies.data.map((company,index)=>(
        <option key={index} value={company.companyID}>{company.name}</option>
      ))}
    </select>


  )

}