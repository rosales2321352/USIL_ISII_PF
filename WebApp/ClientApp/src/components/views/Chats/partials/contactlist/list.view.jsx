import * as React from "react";
import { Box,Paper,Typography } from "@mui/material";
import ClientContext from "../../../../../context/Client/client.context";
import Avatar from '@mui/material/Avatar';

export default function ListView({data}){

  const ClientContext_ = React.useContext(ClientContext);

  const handlerSelectedClient = (e) => {
    ClientContext_.setCurrentClient(data);
  }

  return(
    <Box sx={{width:"100%",cursor:"pointer"}} onClick={handlerSelectedClient}>
      <Paper>
        <Box sx={{display:"flex", alignItems:"center", justifyContent:"start", p:1}}>
          <Box sx={{pr:1}}>
            <Avatar>H</Avatar>
          </Box>
          <Box>
            {data.name ? (<Typography component="span" variant="body2" sx={{display:"block"}}>{data.name}</Typography>)
            : (<Typography component="span" variant="body2" sx={{display:"block"}}>{data.phoneNumber}</Typography>)}
          </Box>
        </Box>
      </Paper>
    </Box>
  )
}