import * as React from "react";
import ClientContext from "../../../../../../context/Client/client.context";
import {Box, Typography} from "@mui/material";
import useApi from "../../../../../../hooks/useApi";
import * as signalR from '@microsoft/signalr';



export default function ChatMessagesView(){

  const ClientContext_ = React.useContext(ClientContext);
  const message_ref = React.createRef();
  const [messageSorted, setMessageSorted] = React.useState([]);
  const [lastReceivedMessage, setLastReceivedMessage] = React.useState(null);
  const [connectionError, setConnectionError] = React.useState(null);

  React.useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("/chatHub")
      .withAutomaticReconnect()
      .build();

    connection.serverTimeoutInMilliseconds = 100000;

    connection.start()
      .then(() => {
        console.log("Conexión exitosa con el servidor SignalR");
      })
      .catch(error => {
        console.error("Error al conectar:", error);
        setConnectionError(error);
      });

    connection.on("ReceiveMessage", function (user, message) {
      console.log(`Mensaje recibido de ${user}: ${message}`);
      setLastReceivedMessage({ user, message });
    });

    return () => {
      connection.stop();
    };
  }, []);

  const getClientId = () => {
    if (ClientContext_.current_client) {
      if (ClientContext_.current_client.clientId) {
        return ClientContext_.current_client.clientId;
      }
    }
    return 0;
  };

  const messages = useApi({
    url: `https://localhost:44445/api/conversations/messages/${getClientId()}`,
    options: {
      method: "GET",
    },
    condition: [ClientContext_.current_client, lastReceivedMessage],
  });

  React.useEffect(() => {
    if (messages && Array.isArray(messages.data)) {
      setMessageSorted(messages.data.sort((a, b) => {
        if (a.timestamp < b.timestamp) {
          return -1;
        }
        if (a.timestamp > b.timestamp) {
          return 1;
        }
        return 0;
      }));
      let container = message_ref.current;
      container.scrollTop = container.scrollHeight;
    }
  }, [messages]);

  return (
    <Box ref={message_ref} sx={{
      height: "calc(100% - 260px)",
      overflow: "hidden",
      overflowY: "auto",
      padding:"0 15px",
    }}>
      <Box position="alternate">
        {
          Array.isArray(messageSorted) && messageSorted.map((message, index) => (
            <Box key={index} sx={{
              display:"flex",
              alignItems:"center",
              justifyContent: message.whatsappID === ClientContext_.current_client.whatsappData.whatsappID ? "start" : "end",
              float: message.whatsappID === ClientContext_.current_client.whatsappData.whatsappID ? "inherit" : "inline-end",
              maxWidth:"70%",
              width:"max-content",  
              
            }}>
              <Box sx={{
                p:1,
                backgroundColor: message.whatsappID === ClientContext_.current_client.whatsappData.whatsappID ?"#fff":"#1976d2",
                color: message.whatsappID === ClientContext_.current_client.whatsappData.whatsappID ?"#000":"#fff",
                margin:"10px 0",
                borderRadius:"5px",
              }}>
                <Typography component="span" variant="body2" >{message.text} - {message.whatsappID} - {ClientContext_.current_client.whatsappData.whatsappID}</Typography>
              </Box>
            </Box>
          ))
        }
      </Box>
    </Box>
  )

}