import React, { Component } from 'react';
import { Card, CardContent, Typography, IconButton } from '@mui/material';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';

export class EventBarView extends Component {
    static displayName = EventBarView.name;

    state = {
        events: []
    }

    formatTime(timeString) {
        const [hours, minutes] = timeString.split(':');
        return `${hours}:${minutes}`;
    }

    componentDidMount() {
        fetch('api/Events/all')
            .then(response => response.json())
            .then(data => {
                this.setState({ events: data.data });
            })
            .catch(error => {
                console.error("Hubo un error cargando los eventos:", error);
            });
    }

    render() {
        return (
            <div style={{ paddingRight: '40px' }} >
                <h3>Eventos</h3>
                {this.state.events.map(event => (
                    <Card key={event.eventID} style={{ marginBottom: '20px' }}>
                        <CardContent>
                            <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                                <div style={{ display: 'flex', alignItems: 'center' }}>
                                    <CalendarMonthIcon />
                                    <Typography variant="h6" style={{ marginLeft: '10px' }}>
                                        {event.title}
                                    </Typography>
                                </div>
                                <IconButton>
                                    {/* Puedes reemplazar este ícono o agregar una acción cuando se cliquea */}
                                    {/* <TuIconoAqui /> */}
                                </IconButton>
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
            </div>
        );
    }
}
