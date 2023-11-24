import { Box, Grid, Paper } from "@mui/material";
import Tableview from "./table/table.view";
import useApi from "../../../hooks/useApi";
import { useContext } from "react";
import ContactosContext from "../../../context/Contactos/contactos.context";
import { EventBarView } from "../Events/eventBar.view";

export default function Contactos() {
    const {reload} = useContext(ContactosContext);

    const data = useApi({
        url: process.env.REACT_APP_URL_CLIENT_LIST ,
        options: {
            method: "GET",
        },
        condition: [reload]
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
                        <Paper sx={{ height: 'calc(100vh - 78px)', p:2,
                                paddingRight: 0,
                                overflow: 'hidden',
                                overflowY: 'auto',
                                width: '100%',
                                }} className="eve">
                                <EventBarView />
                        </Paper>
                    </Grid>

                </Grid>
            </Box>
    )
}