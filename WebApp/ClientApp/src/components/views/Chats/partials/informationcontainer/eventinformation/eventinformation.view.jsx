import React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import { Box , Paper, Typography } from '@mui/material';
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
        <Box sx={{borderBottom:"1px solid #000",pb:1}}>
          <Typography sx={{fontSize:"14px"}}>Eventos</Typography>
        </Box>
        {events && Array.isArray(events.data) && events.data.length > 0 && 
          events.data.map((event,index) => (
            <React.Fragment key={index}>
              <EventCardView event={event}/>
            </React.Fragment> 
          ))
        }    
        {events && Array.isArray(events.data) && events.data.length === 0 &&
        <Box sx={{textAlign:"center"}}>
          <Paper sx={{p:2}}>
            <Typography sx={{fontSize:"14px"}}>No hay eventos</Typography>
          </Paper>
        </Box>
        }
      </Box>
    </>
  )
}