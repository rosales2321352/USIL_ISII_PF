import * as React from 'react';
import ClientContext from '../../../../../../../context/Client/client.context';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import useApi from '../../../../../../../hooks/useApi';

export default function OrderSelectorView(){

  const ClientContext_ = React.useContext(ClientContext);

  const orderStatus = useApi({
    url: process.env.REACT_APP_URL_ORDER_STATUS_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  })

  const [age, setAge] = React.useState('');

  const handleChange = (event) => {
    //console.log(event.target.selectedOptions[0].value);
    setAge(event.target.value);
  };

  return(
    <select className='form-select' style={{width:"250px",display:"inline-block"}}   value={age} onChange={handleChange}>
      <option value="">Etapa de Orden</option>
      {orderStatus.data && Array.isArray(orderStatus.data) && orderStatus.data.map((order,index)=>(
        <option key={index} value={order.orderStatusID}>{order.name}</option>
      ))}
    </select>


  )

}