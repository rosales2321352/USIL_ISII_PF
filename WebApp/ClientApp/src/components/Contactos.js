import React, { Component } from 'react';
import Grid from '@mui/material/Grid';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import CardContent from '@mui/material/CardContent';
import "../custom.css";
import PermIdentityIcon from '@mui/icons-material/PermIdentity';
import CalendarTodayIcon from '@mui/icons-material/CalendarToday';
import Typography from '@mui/material/Typography';
import Accordion  from '../components/NewFolder/Accordion';


export class Contactos extends Component {

    //<NavBar/>
    render() {
        return (
            <>
            <Box height={30} />  
            <Box sx={{ display: "flex" }}>
                <Box component="main" sx={{flexGrow:1,p:3}}>
                   <Grid container spacing={2}>
                       <Grid item xs={8}>
                                <Card sx={{ height: 60 + "vh" }}>
                                    <CardContent>

                                        <h1>Tablat</h1>
                                    </CardContent>
                                </Card>
                       </Grid>
                       <Grid item xs={4}>
                                <Stack spacing={2}>
                                    <Card sx={{ minWidth: 49 + "%", height: 150 }} className="gradient">
                                        <CardContent>
                                            <Stack spacing={2} direction="row">
                                                <div>
                                                    <CalendarTodayIcon />
                                                </div> 
                                                
                                                <div className="paddingall">
                                                    <Typography gutterBotom variant="h5" component="div" sx={{ color: "#000000" }}>
                                                        <div className="reutittle">
                                                            Reuniones
                                                        </div>
                                                    </Typography>
                                                </div>
                                            </Stack>
                                            <Accordion /> 

                                        </CardContent>
                                    </Card>
                                    <Grid item xs={12}>
                                        <Card sx={{ height: 60 + "vh" }}>
                                            <CardContent>
                                                <Stack spacing={2} direction="row">
                                                    <div>
                                                        <PermIdentityIcon />
                                                    </div>

                                                    <div className="paddingall">
                                                        <Typography gutterBotom variant="h5" component="div" sx={{ color: "#FAA86F" }}>
                                                            <div className="reutittle">
                                                                Informacion
                                                            </div>
                                                        </Typography>

                                                    </div>


                                                </Stack>
                                            </CardContent>
                                        </Card>
                                    </Grid>

                                    <Box height={30} />
                                </Stack>
                       </Grid>

                   </Grid>
                </Box>
            </Box >

             </>
        );
    }
    

}