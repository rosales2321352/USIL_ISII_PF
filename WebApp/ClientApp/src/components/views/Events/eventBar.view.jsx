import React, { Component } from 'react';
import { Card, CardContent, Typography, Dialog, DialogTitle, DialogContent, IconButton, Button, DialogActions, TextField } from '@mui/material';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import CloseIcon from '@mui/icons-material/Close';
import AddIcon from '@mui/icons-material/Add';
import Autocomplete from '@mui/material/Autocomplete';

export class EventBarView extends Component {
    static displayName = EventBarView.name;

    state = {
        events: [],
        isDialogOpen: false,
        isAddEventModalOpen: false, // Add this line to define the state variable
        clients: [],
        eventTypes: [],
        newEvent: {
            title: '',
            date: new Date(),
            startTime: new Date(),
            endTime: new Date(),
            description: '',
            clientID: '',
            eventTypeID: ''
        },
        clients: [],
        selectedClientId: null,
        selectedEvent: null // You might want to define this as well if you are using it
    }


    formatTime(timeString) {
        const [hours, minutes] = timeString.split(':');
        return `${hours}:${minutes}`;
    }

    componentDidMount() {
        this.loadEvents();
    }

    loadEvents = () => {
        fetch('api/Events/all')
            .then(response => response.json())
            .then(data => {
                this.setState({ events: data.data });
            })
            .catch(error => {
                console.error("Hubo un error cargando los eventos:", error);
            });
    }

    loadClients = async () => {
        try {
            const response = await fetch('api/clients/all');
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();
            this.setState({ clients: data.data });
        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
    }

    loadEventTypes = async () => {
        try {
            const response = await fetch('api/event-types/all');
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const result = await response.json();
            if (result.statusCode === 200) {
                this.setState({ eventTypes: result.data });
            } else {
                console.error('Failed to load event types:', result);
            }
        } catch (error) {
            console.error("There was a problem with the fetch operation:", error);
        }
    }

    fetchEventDetails = (eventId) => {
        fetch(`api/Events/detail/${eventId}`)
            .then(response => response.json())
            .then(data => {
                this.setState({ selectedEvent: data.data, isDialogOpen: true });
            })
            .catch(error => {
                console.error("Hubo un error cargando los detalles del evento:", error);
            });
    }

    handleClose = () => {
        this.setState({ isDialogOpen: false, selectedEvent: null });
    }

    handleAddEvent = () => {
        this.loadClients();
        this.loadEventTypes();
        this.setState({ isAddEventModalOpen: true });
    }

    handleAddEventClose = () => {
        this.setState({ isAddEventModalOpen: false });
    }

    handleSaveEvent = () => {
        const { newEvent, selectedClientId } = this.state;

        if (newEvent.endTime <= newEvent.startTime) {
            alert('La hora de fin debe ser después de la hora de inicio.');
            return; 
        }

        const formattedDate = newEvent.date.toISOString().split('T')[0];
        const formattedStartTime = newEvent.startTime.toISOString().split('T')[1].substring(0, 5) + ":00"; // add seconds
        const formattedEndTime = newEvent.endTime.toISOString().split('T')[1].substring(0, 5) + ":00"; // add seconds

        const payload = {
            clientID: selectedClientId,
            sellerID: 1, 
            title: newEvent.title,
            dateAssigned: formattedDate,
            beginTime: formattedStartTime,
            endTime: formattedEndTime,
            description: newEvent.description,
            eventTypeID: newEvent.eventTypeID
        };

        fetch('api/Events/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(payload),
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                const contentType = response.headers.get("content-type");
                if (contentType && contentType.indexOf("application/json") !== -1) {
                    return response.json();
                } else {
                    return response.text();
                }
            })
            .then(data => {
                console.log(data);
                this.handleAddEventClose();
                this.loadEvents();
            })
            .catch(error => {
                console.error("Hubo un problema con la petición fetch:", error);
            });

    }

    handleDeleteEvent = () => {
        const { selectedEvent } = this.state;
        if (selectedEvent && selectedEvent.eventID) {
            fetch(`api/Events/delete`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ eventID: selectedEvent.eventID }),
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! Status: ${response.status}`);
                    }
                    const contentType = response.headers.get("content-type");
                    if (contentType && contentType.indexOf("application/json") !== -1) {
                        return response.json();
                    } else {
                        return response.text();
                    }
                })
                .then(data => {
                    console.log(data);
                    this.handleClose();
                    this.loadEvents(); 
                })
                .catch(error => {
                    console.error("Hubo un problema con la petición fetch:", error);
                });
        }
    }

    render() {
        const { events, isDialogOpen, selectedEvent, isAddEventModalOpen, newEvent } = this.state;

        return (
            <div style={{ paddingRight: '40px', marginTop: 10 }} >
                <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '20px' }}>
                    <h3 style={{ margin: 0 }}>Eventos</h3>
                    <IconButton onClick={this.handleAddEvent} >
                        <AddIcon />
                    </IconButton>
                </div>
                {this.state.events.map(event => (
                    <Card key={event.eventID} style={{ marginBottom: '20px' }} onClick={() => this.fetchEventDetails(event.eventID)} >
                        <CardContent>
                            <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                                <div style={{ display: 'flex', alignItems: 'center' }}>
                                    <CalendarMonthIcon />
                                    <Typography variant="h6" style={{ marginLeft: '10px' }}>
                                        {event.title}
                                    </Typography>
                                </div>
                            </div>
                            <Typography color="textSecondary">
                                {event.dateAssigned}, {this.formatTime(event.beginTime)} - {this.formatTime(event.endTime)}
                            </Typography>
                            <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                {event.description}
                            </Typography>
                            <Typography color="textSecondary" >
                                <strong>Cliente: </strong> {event.client.name}
                            </Typography>
                        </CardContent>
                    </Card>
                ))}
                <Dialog open={isDialogOpen} onClose={this.handleClose} maxWidth="sm" fullWidth>
                    <DialogTitle>Detalles del Evento
                        <IconButton onClick={this.handleClose} style={{ position: 'absolute', right: '10px', top: '10px' }}>
                            <CloseIcon />
                        </IconButton>
                    </DialogTitle>
                    <DialogContent>
                        {selectedEvent && (
                            <>
                                <Typography variant="h6">{selectedEvent.title}</Typography>
                                <Typography color="textSecondary">
                                    Fecha: {selectedEvent.dateAssigned}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Hora: {this.formatTime(selectedEvent.beginTime)} - {this.formatTime(selectedEvent.endTime)}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Descripción: {selectedEvent.description}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Cliente: {selectedEvent.client.name}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Teléfono: {selectedEvent.client.phoneNumber}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Email: {selectedEvent.client.email}
                                </Typography>
                                <Typography color="textSecondary" style={{ marginTop: '5px' }}>
                                    Tipo de reunión: {selectedEvent.status.name}
                                </Typography>
                            </>
                        )}
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleClose} color="primary">
                            Cerrar
                        </Button>
                        {selectedEvent && (
                            <Button onClick={this.handleDeleteEvent} color="secondary">
                                Eliminar
                            </Button>
                        )}
                    </DialogActions>

                </Dialog>
                <Dialog open={isAddEventModalOpen} onClose={this.handleAddEventClose} maxWidth="sm" fullWidth>
                    <DialogTitle>Agregar Nuevo Evento</DialogTitle>
                    <DialogContent>
                        <TextField
                            label="Título del Evento"
                            fullWidth
                            margin="normal"
                            value={newEvent.title}
                            onChange={(e) => this.setState({ newEvent: { ...newEvent, title: e.target.value } })}
                        />
                        <TextField
                            label="Fecha del Evento"
                            type="date"
                            value={newEvent.date.toISOString().split('T')[0]}
                            fullWidth
                            InputLabelProps={{
                                shrink: true,
                            }}
                            margin="normal"
                            onChange={(e) => this.setState({ newEvent: { ...newEvent, date: new Date(e.target.value) } })}
                        />
                        <TextField
                            label="Hora de Inicio"
                            type="time"
                            value={newEvent.startTime.toISOString().split('T')[1].substring(0, 5)}
                            fullWidth
                            InputLabelProps={{
                                shrink: true,
                            }}
                            inputProps={{
                                step: 300, // 5 min
                            }}
                            margin="normal"
                            onChange={(e) => this.setState({ newEvent: { ...newEvent, startTime: new Date(newEvent.date.toDateString() + ' ' + e.target.value) } })}
                        />
                        <TextField
                            label="Hora de Fin"
                            type="time"
                            value={newEvent.endTime.toISOString().split('T')[1].substring(0, 5)}
                            fullWidth
                            InputLabelProps={{
                                shrink: true,
                            }}
                            inputProps={{
                                step: 300, // 5 min
                            }}
                            margin="normal"
                            onChange={(e) => this.setState({ newEvent: { ...newEvent, endTime: new Date(newEvent.date.toDateString() + ' ' + e.target.value) } })}
                        />
                        <TextField
                            label="Descripción del Evento"
                            fullWidth
                            margin="normal"
                            value={newEvent.description}
                            onChange={(e) => this.setState({ newEvent: { ...newEvent, description: e.target.value } })}
                        />
                        <Autocomplete
                            id="client-selection"
                            options={this.state.clients}
                            getOptionLabel={(client) => `${client.name} - ${client.phoneNumber}`}
                            value={
                                this.state.clients.find(client => client.clientId === this.state.selectedClientId) || null
                            }
                            onChange={(event, newValue) => {
                                this.setState({ selectedClientId: newValue ? newValue.clientId : null });
                            }}
                            renderInput={(params) => (
                                <TextField
                                    {...params}
                                    label="Selecciona un cliente"
                                    variant="outlined"
                                    margin="normal"
                                    fullWidth
                                />
                            )}
                        />
                        <Autocomplete
                            id="event-type-selection"
                            options={this.state.eventTypes}
                            getOptionLabel={(option) => option.name}
                            onChange={(event, newValue) => {
                                this.setState({ newEvent: { ...newEvent, eventTypeID: newValue ? newValue.eventTypeID : '' } });
                            }}
                            renderInput={(params) => (
                                <TextField
                                    {...params}
                                    label="Selecciona un tipo de evento"
                                    variant="outlined"
                                    margin="normal"
                                    fullWidth
                                />
                            )}
                        />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleAddEventClose}>Cancelar</Button>
                        <Button onClick={this.handleSaveEvent}>Guardar</Button>
                    </DialogActions>
                </Dialog>
            </div>
        );
    }
}
