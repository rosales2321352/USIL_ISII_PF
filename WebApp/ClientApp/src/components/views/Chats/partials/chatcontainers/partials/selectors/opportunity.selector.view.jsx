import * as React from 'react';
import ClientContext from '../../../../../../../context/Client/client.context';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import useApi from '../../../../../../../hooks/useApi';

export default function OpportunitySelectorView(){

  const ClientContext_ = React.useContext(ClientContext);

  const opportunities = useApi({
    url: process.env.REACT_APP_URL_OPPORTUNITY_STATUS_LIST,
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
      <InputLabel id="demo-select-small-label">Etapa de Oportunidad</InputLabel>
      <Select
        labelId="demo-select-small-label"
        id="demo-select-small"
        value={age}
        label="Etapa de Oportunidad"
        onChange={handleChange}
      >
        <MenuItem value="">
          <em>Sin etapa</em>
        </MenuItem>
        {opportunities.data && Array.isArray(opportunities.data) && opportunities.data.map((opportunity,index)=>(
          <MenuItem key={index} value={opportunity.opportunityStatusID}>{opportunity.name}</MenuItem>
        ))}
      </Select>
    </FormControl>
  )

}