import { Box, Grid, Paper } from "@mui/material";
import ContactListView from "./partials/contactlist/contactlist.view";
import ChatContainersView from "./partials/chatcontainers/chatcontainers.view";
import useApi, { submitApi } from "../../../hooks/useApi";
import { useEffect,useState } from "react";

export default function ChatView(){

  return (
    <Box sx={{p:1,width:"100%"}}>
      <Grid container spacing={1}>
        <Grid item xs={12} md={3} >
          <Paper sx={{height: 'calc(100vh - 78px)'}}>
            <ContactListView/>
          </Paper>
        </Grid>
        <Grid item xs={12} md={6}>
          <Paper sx={{height: 'calc(100vh - 78px)'}}>
            <ChatContainersView/>
          </Paper>
        </Grid>
        <Grid item xs={12} md={3}>
          <Paper sx={{height: 'calc(100vh - 78px)'}}>
            <h1>Chat</h1>
          </Paper>
        </Grid>
      </Grid>
    </Box>
  )
}