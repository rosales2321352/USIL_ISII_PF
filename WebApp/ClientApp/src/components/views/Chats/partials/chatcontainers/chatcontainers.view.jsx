import { useEffect } from "react";
import * as signalR from '@microsoft/signalr';
import { Box, Avatar } from "@mui/material";
import ChatHeaderView from "./partials/chatheader.view";
import bg_wat from "../../../../../assets/img/bg_watt.webp";
import ChatToolsView from "./partials/chattools.view";

export default function ChatContainersView() {

  useEffect(() => {
    // Lógica de conexión con SignalR
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
      });

    // Escuchar eventos desde el servidor
    connection.on("ReceiveMessage", function (user, message) {
      console.log(`Mensaje recibido de ${user}: ${message}`);
    });

    // Cierre de la conexión al desmontar el componente
    return () => {
      connection.stop();
    };
  }, []); // Se ejecuta solo en el montaje del componente

  return (
    <Box sx={{
      position: 'relative',
      height: '100%',
      backgroundImage: `url(${bg_wat})`,
      backgroundSize: 'fill',
      backgroundPosition: 'center',
    }}>
      <ChatHeaderView />
      <Box sx={{
        height: "calc(100% - 300px)"
      }}>2</Box>
      <ChatToolsView />
    </Box>
  )
}