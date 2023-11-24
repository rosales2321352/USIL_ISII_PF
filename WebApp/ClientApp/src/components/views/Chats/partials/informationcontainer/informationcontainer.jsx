import React from 'react';
import {Box} from '@mui/material';
import ClientInformationView from './clientinformation/clientinformation.view';
import EventInformationView from './eventinformation/eventinformation.view';
import NoteInformationView from './noteinformation/noteinformation.view';


export default function InformationContainerView() {


  return (
    <Box sx={{p:1.5,width:"100%",height:"100%",display:"flex",flexDirection:"column",overflow:"hidden",overflowY:"auto"}}>
      <ClientInformationView/>
      <EventInformationView/>
      <NoteInformationView/>
    </Box>
  )
  
}