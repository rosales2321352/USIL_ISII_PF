import React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import NoteContext from '../../../../../../context/Note/note.context';
import {Box,Paper,Typography} from '@mui/material';
import useApi from '../../../../../../hooks/useApi';
import NoteCardView from './notecard.view';

export default function NoteInformationView(){
  const [reload, setReload] = React.useState(false);

  const ClientContext_ = React.useContext(ClientContext);
  const NoteContext_ = React.useContext(NoteContext);
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
    condition:[ClientContext_.current_client,NoteContext_.reload]
  });

  return(
    <>
      <Box sx={{mt:2}}>
        <Box sx={{borderBottom:"1px solid #000",pb:1}}>
          <Typography sx={{fontSize:"14px"}}>Notas</Typography>
        </Box>
        {notes && Array.isArray(notes.data) && notes.data.length > 0 && 
          notes.data.map((notes,index) => (
            <React.Fragment key={index}>
              <NoteCardView note={notes}/>
            </React.Fragment> 
          ))
        } 
        {notes && Array.isArray(notes.data) && notes.data.length === 0 && 
          <Box sx={{textAlign:"center"}}>
            <Paper sx={{p:2}}>
              <Typography sx={{fontSize:"14px"}}>No hay notas</Typography>
            </Paper>
          </Box>
        }
      </Box>
    </>
  )

}