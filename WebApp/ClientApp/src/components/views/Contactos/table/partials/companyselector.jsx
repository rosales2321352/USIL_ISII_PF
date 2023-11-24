import * as React from 'react';
import useApi from '../../../../../hooks/useApi';

export default function CompanySelector({data_}){

    const {data, setData} = data_;

  const companies = useApi({
    url: process.env.REACT_APP_URL_COMPANY_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  })

  const handleChange = (event) => {
    //console.log(event.target.selectedOptions[0].value);
    setData({...data, company:{...data.company,companyID:event.target.value}});
  };

  return(
    <select className='form-control' style={{width:"250px",display:"inline-block"}} value={data.company.companyID} onChange={handleChange}>
      <option value="">Asignar Empresa</option>
      {companies.data && Array.isArray(companies.data) && companies.data.map((company,index)=>(
        <option key={index} value={company.companyID}>{company.name}</option>
      ))}
    </select>

  )

}