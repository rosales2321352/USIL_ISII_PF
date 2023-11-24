import React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import {Box,Typography} from '@mui/material';
import useApi from '../../../../../../hooks/useApi';
import NoteCardView from './notecard.view';

export default function NoteInformationView(){
  const ClientContext_ = React.useContext(ClientContext);

  const getClientId = () => {
    if(ClientContext_.current_client){
      if(ClientContext_.current_client.clientId){
        return ClientContext_.current_client.clientId;
      }      
    }
    return 0;
  }

  const notes = useApi({
    url: process.env.REACT_APP_URL_NOTE_LIST +'/'+ getClientId(),
    options:{
      method: "GET",
    },
    condition:[ClientContext_.current_client]
  });

  return(
    <>
      <Box sx={{mt:2}}>
        <Box>
          <Typography sx={{fontSize:"14px"}}>Notas</Typography>
        </Box>
        {notes && Array.isArray(notes.data) && notes.data.length > 0 && 
          notes.data.map((notes,index) => (
            <React.Fragment key={index}>
              <NoteCardView note={notes} />
            </React.Fragment> 
          ))
        } 
      </Box>
    </>
  )

}