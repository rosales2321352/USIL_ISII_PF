import * as React from "react";
import ClientContext from "../../../../../../context/Client/client.context";
import {Box,IconButton,Tooltip,Typography} from "@mui/material"
import Avatar from '@mui/material/Avatar';
import useApi from "../../../../../../hooks/useApi";
import TodayIcon from '@mui/icons-material/Today';
import OpportunitySelectorView from "./selectors/opportunity.selector.view";
import OrderSelectorView from "./selectors/order.selector.view";



export default function ChatHeaderView(){
  
  const ClientContext_ = React.useContext(ClientContext);

  

  const getClientId = () => {
    if(ClientContext_.current_client){
      if(ClientContext_.current_client.clientId){
        return ClientContext_.current_client.clientId;
      }      
    }
    return 0;
  }

  const client = useApi({
    url: `${process.env.REACT_APP_URL_CLIENT_DETAIL}/${getClientId()}`,
    options:{
      method: "GET",
    },
    condition:[ClientContext_.current_client]
  });

  

  return(
    <Box sx={{
      border: '1px solid #e0e0e0',
      height: "120px",
      borderRadius: '0 0 30px 30px',
      backgroundColor: 'white',
      p:1,pl:2
    }}>
      <Box sx={{
        display:"flex",
        alignItems:"start",
        justifyContent:"space-between",
      }}>
        {client.data &&
          <React.Fragment>
            <Box sx={{
              display:"flex",
              alignItems:"center",
              justifyContent:"space-between",
            }}>
              <Box>
                <Avatar sx={{ width: 50, height: 50 }}>D</Avatar>
              </Box>
              <Box sx={{ml:1}}>
                {client.data.name ? 
                (<Typography component="span" variant="body1" sx={{display:"block"}}>{client.data.name}</Typography>)
                :
                (<Typography component="span" variant="body1" sx={{display:"block"}}>{client.data.phoneNumber}</Typography>)
                }
                
              </Box>
              <Box sx={{ml:1}}>
                <Tooltip title="Mis Eventos">
                  <IconButton sx={{
                    backgroundColor:"#FCF2CC",
                    border:"1px solid #E9A13B",
                    "&:hover":{
                      backgroundColor:"#FCF2CC !important",
                    },
                  }}>
                    <TodayIcon sx={{color:"#E9A13B"}}/>
                  </IconButton>
                </Tooltip>
              </Box>
            </Box>
            
          </React.Fragment>
        }
      </Box>
      <Box>
        <OpportunitySelectorView/>
        <OrderSelectorView/>
      </Box>
    </Box>
  )

}