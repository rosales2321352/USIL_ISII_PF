import { Box, TextField, Button, Typography } from "@mui/material";
import PaginationLayout from "../../../../layouts/pagination/pagination.layout";
import useApi from "../../../../../hooks/useApi";
import ListView from "./list.view";
import { Fragment } from "react";


export default function ContactListView(){

  const clients = useApi({
    url: process.env.REACT_APP_URL_CLIENT_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  });

  return (
    <Box sx={{
      p:1,
      height: '100%',
    }}>
      <Box sx={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        height: '40px',
      }}>
        <TextField id="search-form-contact-list" label="Buscar Contacto" variant="outlined" size="small" sx={{
          mr:1,
          fontSize: 10,
        }}/>
        <Button variant="contained" >Buscar</Button>
      </Box>
      <Box sx={{pt: "5px",mb: "5px", borderBottom: "2px solid #444"}}>
        <Typography component="span"  sx={{display:"block"}}>Contactos</Typography>
      </Box>
      <Box sx={{
        height: 'calc(100% - 120px)'
      }}>
        {clients.data && Array.isArray(clients.data) && clients.data.length > 0 &&
          clients.data.map((el,index) => (
            <Fragment key={index}>
              <ListView data={el}/>
            </Fragment>
          ))
        }
      </Box>
      <Box sx={{
        height: '40px',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
      }}>
        {clients.data && Array.isArray(clients.data) && clients.data.length > 10 &&
          <PaginationLayout/>
        } 
      </Box>
    </Box>
  );
}