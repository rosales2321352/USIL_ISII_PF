import React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import { Box , Typography } from '@mui/material';
import useApi from '../../../../../../hooks/useApi';
import EventCardView from './eventcard.view';

export default function EventInformationView(){

  const ClientContext_ = React.useContext(ClientContext);

  const getClientId = () => {
    if(ClientContext_.current_client){
      if(ClientContext_.current_client.clientId){
        return ClientContext_.current_client.clientId;
      }      
    }
    return 0;
  }

  const events = useApi({
    url: process.env.REACT_APP_URL_EVENTS_LIST +'/'+ getClientId(),
    options:{
      method: "GET",
    },
    condition:[ClientContext_.current_client]
  });

  

  return(
    <>
      <Box sx={{mt:2}}>
        <Box>
          <Typography sx={{fontSize:"14px"}}>Eventos</Typography>
        </Box>
        {events && Array.isArray(events.data) && events.data.length > 0 && 
          events.data.map((event,index) => (
            <React.Fragment key={index}>
              <EventCardView event={event}/>
            </React.Fragment> 
          ))
        }    
      </Box>
    </>
  )
}