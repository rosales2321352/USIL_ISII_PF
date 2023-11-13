import useApi from "../../../hooks/useApi";
import { Box, Grid, Paper } from "@mui/material";
import Tableview from "./partials/tablecontainers/table.view";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Edit from "./partials/tablecontainers/Crud/edit.view";

export default function Contactos() {
    const data = useApi({
        url: "https://localhost:44445/api/client/lista",
        options: {
            method: "GET",
        },
        condition: []
    });

    return (
        <BrowserRouter>
        <Routes>
        <Box sx={{ p: 1 }}>
            <Grid container spacing={1}>
                <Grid item xs={12} md={9} >
                    <Paper xs={{ height: 'calc(100vh - 78px)' }}>
                        <Route path="client" element={<Tableview />}/>
                        <Route path="update/:id" element={<Edit/>}/>
                    </Paper>
                </Grid>
              
                <Grid item xs={12} md={3}>
                    <Paper sx={{ height: 'calc(100vh - 78px)' }}>
                        <h1>Event</h1>
                    </Paper>
                </Grid>
            </Grid>
        </Box>
                   
        </Routes>
        </BrowserRouter>
    )

}