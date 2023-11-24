import React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import { ClientForm} from '../../../../../common/interface';
import {Box,Typography} from '@mui/material';
import CompanyInformationView from './companyinformation.view';
import { submitApi } from '../../../../../../hooks/useApi';
import CompanySelectorView from './companyselector.view';

export default function ClientInformationView(){
  
  const [clientForm,setClientForm] = React.useState(ClientForm);
  const [clientFormPrevious,setClientFormPrevious] = React.useState(ClientForm);
  const ClientContext_ = React.useContext(ClientContext);
  const [client, setClient] = React.useState(null);
  const [reload,setReload] = React.useState(false);
  

  React.useEffect(() => {
    setClientForm(ClientForm);
    setClientFormPrevious(ClientForm);
  },[ClientContext_.current_client])

  React.useEffect(() => {
    if(ClientContext_.current_client?.clientId){
      submitApi({
        url: process.env.REACT_APP_URL_CLIENT_DETAIL +'/'+ ClientContext_.current_client.clientId,
        options:{
          method: "GET",
        }
      }).then((data) => {
        if(data && data.statusCode === 200){
          setClient(data.data);
        }
      })
    }      
  },[ClientContext_.current_client,reload])

  React.useEffect(() => {
    
    if(client){
      setClientForm({
        personID: client.clientId || null,
        name: client.name || "",
        phoneNumber: client.phoneNumber || "",
        email: client.email || "",
        companyID: client.company?.companyID || null,
        clientStatusID: client.status?.clientStatusID || null,
        WhatsappID: client.whatsappData?.whatsappID || null,
      });
    }

  },[client])

  const handlerChange = (e) => {
    setClientFormPrevious(clientForm);
    setClientForm({
      ...clientForm,
      [e.target.name]: e.target.value
    })
  }

  const handlerSubmit = (e) => {
    if(client.personID !== null){
      if(clientForm[e.target.name] !== clientFormPrevious[e.target.name]){
        submitApi({
          url: process.env.REACT_APP_URL_CLIENT_UPDATE,
          options:{
            method: "POST",
            body: JSON.stringify(clientForm)
          }
        }).then(() => {
          setReload(!reload);
        })
      }
    }else{
      
    }
  }

  return(
    <>
      <Box>
        <Box sx={{borderBottom:"1px solid #000",pb:1}}>
          <Typography sx={{fontSize:"14px"}}>Información</Typography>
        </Box>
        <Box sx={{mt:2}}>
          <Box className="container-input-client-information"  >
            <Typography sx={{fontSize:"14px"}} component={'span'}>Nombre:</Typography>
            <input type='text' name='name' onBlur={handlerSubmit} onChange={handlerChange} value={clientForm.name}/>
          </Box>
          {/* <Box className="container-input-client-information">
            <Typography sx={{fontSize:"14px"}} component={'span'}>Númbre:</Typography>
            <input type='text' name='phoneNumber' onBlur={handlerSubmit} onChange={handlerChange} value={clientForm.phoneNumber}/>
          </Box> */}
          <Box className="container-input-client-information">
            <Typography sx={{fontSize:"14px"}} component={'span'}>Correo:</Typography>
            <input type='text' name='email' onBlur={handlerSubmit} onChange={handlerChange} value={clientForm.email}/>
          </Box>
          <Box className="container-input-client-information">
            <Typography sx={{fontSize:"14px"}} component={'span'}>Empresa:</Typography>
            {/* <input type='text' name='email' onBlur={handlerSubmit} onChange={handlerChange} value={clientForm.email}/> */}
            <CompanySelectorView onBlur={handlerSubmit} companyID={clientForm.companyID} form={{clientForm, setClientForm}} setClientFormPrevious={setClientFormPrevious}/>
          </Box>
        </Box>
        {/* <CompanyInformationView/> */}
      </Box>
    </>
  )
}