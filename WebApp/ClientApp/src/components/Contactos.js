import React, { Component } from 'react';
import Grid from '@mui/material/Grid';
//import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
//import Paper from '@mui/material/Paper';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import CardContent from '@mui/material/CardContent';
import "../custom.css";
import PermIdentityIcon from '@mui/icons-material/PermIdentity';
import CalendarTodayIcon from '@mui/icons-material/CalendarToday';
import Typography from '@mui/material/Typography';
import { Button, IconButton } from '@mui/material';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Table from "./table/Table";
import styled from 'styled-components';
import Modal from "./table/Modal";
 

export class Contactos extends Component {
    static displayName = Contactos.name;

    constructor(props) {
        super(props);
        this.state = {
            estadoModal1: false,
        };
    }

    handleOpenModal = () => {
        this.setState({ estadoModal1: true });
    };

    handleCloseModal = () => {
        this.setState({ estadoModal1: false });
    };

    render() {
        const { row } = this.props;
        const { estadoModal1 } = this.state;

        return (
            <>
            <Box height={30} />  
            <Box sx={{ display: "flex" }}>
                <Box component="main" sx={{flexGrow:1,p:3}} >
                   <Grid container spacing={2} >
                            <Grid item xs={8} >
                                <encabezado>Contctos</encabezado>
                                <Icon  onClick={this.handleOpenModal}>
                                    <AddCircleIcon />
                                </Icon>
                            
                                <Card sx={{
                                    height: 83 + "vh"
                                }}>
                                    <CardContent>
                                        <Table row={row} />
                                    </CardContent>
                                </Card>
                       </Grid>
                       <Grid item xs={4}>
                           <Grid container>
                                <Stack spacing={2}>
                                   <Card sx={{ minWidth: "160%", height: 170 }}>
                                        <CardContent>
                                            <Stack spacing={2} direction="row">
                                                    <div>
                                                        <CalendarTodayIcon sx={{ color: "#FAA86F" }} />
                                                    </div> 
                                                
                                                    <div className="paddingall">
                                                        <Typography gutterBottom variant="h5" component="div" sx={{ color: "#FAA86F" }}>
                                                            <div className="reutittle">
                                                                Reuniones
                                                            </div>
                                                        </Typography>
                                                    </div>
                                            </Stack>
                                        </CardContent>
                                   </Card>                                    
                                       <Grid item xs={12}>
                                            <Card sx={{ minWidth: "160%", height: 60 + "vh" }}>
                                            <CardContent>
                                                <Stack spacing={2} direction="row">
                                                    <div>
                                                            <PermIdentityIcon sx={{ color: "#FAA86F" }} />
                                                    </div>

                                                    <div className="paddingall">
                                                        <Typography gutterBottom variant="h5" component="div" sx={{ color: "#FAA86F" }}>
                                                            <div className="reutittle">
                                                                    <div className="reutittle"> Informacion</div>
                                                                    {row && (
                                                                        <>
                                                                            <h2>Detalles del Cliente</h2>
                                                                            <p>Nombre: {row.nombre}</p>
                                                                            <p>País: {row.pais}</p>
                                                                            <p>Telefono: {row.telefono}</p>
                                                                            <p>Direccion: {row.direccion}</p>
                                                                            <p>Transacciones: {row.transacciones}</p>
                                                                            <p>Tipo de Cliente: {row.tipoCliente}</p>
                                                                        </>
                                                                    )}
                                                            </div>
                                                        </Typography>
                                                    </div>
                                                </Stack>
                                            </CardContent>
                                        </Card>
                                    </Grid>
                                </Stack>
                           </Grid>
                       </Grid>
                   </Grid>
                </Box>
            </Box>
            </>
        );
    }
}

export default Contactos;



const Icon = styled.button`
    position: center;
    top: 15px;
    right: 20px;
    widht: 30px;
    height: 30px;
    border: none;
    background:none;
    cursor: pointer;
    transition: .3 ease all;
    border-radius: 5px;
    color: "#FAA86F";
    

`;
