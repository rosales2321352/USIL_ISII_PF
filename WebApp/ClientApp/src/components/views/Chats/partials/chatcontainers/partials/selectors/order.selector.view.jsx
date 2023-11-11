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
    setAge(event.target.value);
  };

  return(
    <FormControl sx={{ m: 1, minWidth: 200 }} size="small">
      <InputLabel id="demo-select-small-label">Etapa de Orden</InputLabel>
      <Select
        labelId="demo-select-small-label"
        id="demo-select-small"
        value={age}
        label="Etapa de Orden"
        onChange={handleChange}
      >
        <MenuItem value="">
          <em>Sin etapa</em>
        </MenuItem>
        {orderStatus.data && Array.isArray(orderStatus.data) && orderStatus.data.map((order,index)=>(
          <MenuItem key={index} value={order.orderStatusID}>{order.name}</MenuItem>
        ))}
      </Select>
    </FormControl>
  )

}