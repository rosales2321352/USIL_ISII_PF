import React, { Component } from 'react';
import { Box, Grid, Paper, Button, Typography, Avatar } from '@mui/material';
import { Edit } from '@mui/icons-material';

const contacts = [
    {
        name: 'Laleska Arroyo Aquino',
        type: 'Cliente',
        number: '904089518',
        country: 'Perú',
        address: 'Calle 12. Miraflores 45',
        transactions: 1,
    },
    {
        name: 'Mauro',
        type: 'Cliente viejo',
        number: '666666666',
        country: 'Perú',
        address: 'Calle 12. Miraflores 45',
        transactions: 5,
    },
];

export class FinalizadoView extends Component {

    state = {
        selectedContact: null,
    }


    handleSelectContact = (contact) => {
        this.setState({ selectedContact: contact });
    }

    render() {
        const { selectedContact } = this.state;

        return (
            <Box sx={{ p: 2, bgcolor: '#f5f5f7', height: '100vh' }}>
                <Grid container spacing={2}>
                    <Grid item xs={7}>
                        <Paper elevation={3} sx={{ height: '100%', p: 2, overflow: 'auto' }}>
                            <Typography variant="h5" gutterBottom>Contactos</Typography>
                            {contacts.map((contact, index) => (
                                <Box
                                    key={index}
                                    onClick={() => this.handleSelectContact(contact)}
                                    sx={{ p: 2, mb: 1, cursor: 'pointer', '&:hover': { bgcolor: '#e0e0e3' }, display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}
                                >
                                    <Typography>{contact.name}</Typography>
                                    <Typography>{contact.address}</Typography>
                                </Box>
                            ))}
                        </Paper>
                    </Grid>
                    <Grid item xs={5}>
                        <Paper elevation={3} sx={{ height: '45%', p: 2, mb: 2 }}>
                            <Box sx={{ display: 'flex', justifyContent: 'space-between' }}>
                                <Typography variant="h5">Meetings</Typography>
                                <Typography>{selectedContact ? selectedContact.name : 'Seleccione un contacto'}</Typography>
                            </Box>
                            <Typography variant="body2" color="textSecondary">Miércoles, 22 Sep 12:40 pm - 1:30 pm</Typography>
                        </Paper>
                        <Paper elevation={3} sx={{ height: '53%', p: 2 }}>
                            <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                                <Typography variant="h5">Información</Typography>
                                <Button startIcon={<Edit />} variant="outlined">Editar</Button>
                            </Box>
                            {selectedContact ? (
                                <Box sx={{ mt: 2, display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                                    <Avatar sx={{ width: 60, height: 60, bgcolor: 'gray' }} />
                                    <Typography variant="h6" mt={2}>{selectedContact.name}</Typography>
                                    <Typography mt={1}>Tipo: {selectedContact.type}</Typography>
                                    <Typography>País: {selectedContact.country}</Typography>
                                    <Typography>Número: {selectedContact.number}</Typography>
                                    <Typography>Dirección: {selectedContact.address}</Typography>
                                    <Typography>Transacciones: {selectedContact.transactions}</Typography>
                                </Box>
                            ) : (
                                <Typography>Seleccione un contacto para ver los detalles.</Typography>
                            )}
                        </Paper>
                    </Grid>
                </Grid>
            </Box>
        );
    }
}
