import * as React from 'react';
import ClientContext from '../../../../../../../context/Client/client.context';
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
    <select className='form-control' style={{width:"250px",display:"inline-block"}} value={age} onChange={handleChange}>
      <option value="">Etapa de Oportunidad</option>
      {opportunities.data && Array.isArray(opportunities.data) && opportunities.data.map((opportunity,index)=>(
        <option key={index} value={opportunity.opportunityStatusID}>{opportunity.name}</option>
      ))}
    </select>

  )

}