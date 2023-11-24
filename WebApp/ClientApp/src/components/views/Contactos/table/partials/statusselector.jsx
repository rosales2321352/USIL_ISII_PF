import * as React from 'react';
import useApi from '../../../../../hooks/useApi';

export default function StatusSelector({data_}){

    const {data, setData} = data_;

  const statuscli = useApi({
    url: process.env.REACT_APP_URL_CLIENT_STATUS_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  })

  const handleChange = (event) => {
    //console.log(event.target.selectedOptions[0].value);
    setData({...data, status:{...data.status,clientStatusID:event.target.value}});
  };

  return(
    <select className='form-control' style={{width:"250px",display:"inline-block"}} value={data.status.clientStatusID} onChange={handleChange}>
      <option value="">Asignar Estado: </option>
      {statuscli.data && Array.isArray(statuscli.data) && statuscli.data.map((status,index)=>(
        <option key={index} value={status.clientStatusID}>{status.name}</option>
      ))}
    </select>

  )

}