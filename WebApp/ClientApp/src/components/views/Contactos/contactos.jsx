import { Box, Grid, Paper } from "@mui/material";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Edit from "./table/partials/edit.view";
import Tableview from "./table/table.view";
import useApi from "../../../hooks/useApi";
import { useEffect } from "react";
import EventView from "./table/event";


export default function Contactos() {
    const data = useApi({
        url: process.env.REACT_APP_URL_CLIENT_LIST ,
        options: {
            method: "GET",
        },
        condition: []
    });
    
    return (
        <Box sx={{ width:"100%", p: 1 }}>
            <Grid container spacing={1}>
                <Grid item xs={12} md={9} lg={9}>
                    <Paper xs={{ height: 'calc(100vh - 78px)' }} className="tab">
                       { data && Array.isArray(data.data) && <Tableview data={data} /> }
                    </Paper>
                </Grid>
              
                <Grid item xs={12} md={3} lg={3}>
                    <Paper sx={{ height: 'calc(100vh - 78px)' }} className="eve">
                        <EventView/>
                    </Paper>
                </Grid>

            </Grid>
        </Box>
    )
}