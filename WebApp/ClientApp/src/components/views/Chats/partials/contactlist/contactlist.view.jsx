import { Box, Typography } from "@mui/material";
import PaginationLayout from "../../../../layouts/pagination/pagination.layout";
import useApi from "../../../../../hooks/useApi";
import ListView from "./list.view";
import { Fragment, useEffect } from "react";


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