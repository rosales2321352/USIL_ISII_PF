import useApi, { submitApi } from "../../../hooks/useApi";
import { Box, Grid, Paper } from "@mui/material";
import { useEffect } from "react";

export default function Contactos() {
    const data = useApi({
        url: "https://localhost:44445/api/clients/all",
        options: {
            method: "GET",
        },
        condition: []
    });

    return (
        <Box sx={{ p: 1 }}>
            <Grid container spacing={1}>
                <Grid item xs={12} md={9} >
                    <Paper xs={{ height: 'calc(100vh - 78px)' }}>
                        <h1>Holaaaa</h1>
                    </Paper>
                </Grid>
              
                <Grid item xs={12} md={3}>
                    <Paper sx={{ height: 'calc(100vh - 78px)' }}>
                        <h1>Event</h1>
                    </Paper>
                </Grid>
            </Grid>
        </Box>
    )

}