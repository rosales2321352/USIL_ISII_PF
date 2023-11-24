import React, { useEffect, useState } from 'react';
import EventContext from '../../../context/Event/event.context';
import {  Dialog, DialogTitle, DialogContent, Button, DialogActions, TextField } from '@mui/material';
import Autocomplete from '@mui/material/Autocomplete';
import useApi from '../../../hooks/useApi';
import { format, utcToZonedTime, zonedTimeToUtc } from 'date-fns-tz';




export default function EventDialogView({open, setOpen,event}) {
  const EventContext_ = React.useContext(EventContext);
  const { eventForm,setEventForm} = event;

  const clients = useApi({
    url: process.env.REACT_APP_URL_CLIENT_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  });

  const eventTypes = useApi({
    url: process.env.REACT_APP_URL_EVENT_TYPES_LIST,
    options:{
      method: "GET",
    },
    condition:[]
  });

  const handleAddEventClose = () => {
    setOpen(false);
  }

  const handleSaveEvent = () => {

    if (eventForm.endTime <= eventForm.startTime) {
      alert('La hora de fin debe ser después de la hora de inicio.');
      return; 
    }

    const formattedDate = format(eventForm.date, 'yyyy-MM-dd', { timeZone: 'America/Lima' });
    const formattedStartTime = format(eventForm.startTime, 'HH:mm:ss', { timeZone: 'America/Lima' });
    const formattedEndTime = format(eventForm.endTime, 'HH:mm:ss', { timeZone: 'America/Lima' });

    const payload = {
        clientID: eventForm.clientID,
        sellerID: 1, 
        title: eventForm.title,
        dateAssigned: formattedDate,
        beginTime: formattedStartTime,
        endTime: formattedEndTime,
        description: eventForm.description,
        eventTypeID: eventForm.eventTypeID
    };

    let url = eventForm.eventID ? 'api/Events/edit' : 'api/Events/create';
    let method = eventForm.eventID ? 'PUT' : 'POST';
    if (eventForm.eventID) {
        payload.eventID = eventForm.eventID;
    }

    fetch(url, {
        method: method,
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
            EventContext_.setReload(!EventContext_.reload);
            handleAddEventClose();            
        })
        .catch(error => {
            console.error("Hubo un problema con la petición fetch:", error);
        });

  }


  return(
    <Dialog open={open} onClose={handleAddEventClose} maxWidth="sm" fullWidth>
      <DialogTitle>{eventForm.eventID ? 'Editar Evento' : 'Nuevo Evento'}</DialogTitle>
      <DialogContent>
          <TextField
              label="Título del Evento"
              fullWidth
              margin="normal"
              value={eventForm.title}
              onChange={(e) => setEventForm({...eventForm, title: e.target.value } )}
          />
          <TextField
              label="Fecha del Evento"
              type="date"
              value={eventForm.date?.toISOString().split('T')[0]}
              fullWidth
              InputLabelProps={{
                  shrink: true,
              }}
              margin="normal"
              onChange={(e) => setEventForm({ ...eventForm, date: new Date(e.target.value) } )}
          />
          <TextField
              label="Hora de Inicio"
              type="time"
              value={format(utcToZonedTime(eventForm.startTime, 'America/Lima'), 'HH:mm', { timeZone: 'America/Lima' })}
              fullWidth
              InputLabelProps={{
                  shrink: true,
              }}
              inputProps={{
                  step: 300, // 5 min
              }}
              margin="normal"
              onChange={(e) => {
                   const selectedTime = zonedTimeToUtc(
                      new Date(eventForm.date.toDateString() + ' ' + e.target.value),
                      'America/Lima'
                  );
                  setEventForm({
                      ...eventForm,
                      startTime: selectedTime,
                  });
                }
              }
            />
          <TextField
              label="Hora de Fin"
              type="time"
              value={format(utcToZonedTime(eventForm.endTime, 'America/Lima'), 'HH:mm', { timeZone: 'America/Lima' })}
              fullWidth
              name = "endTime"
              InputLabelProps={{
                  shrink: true,
              }}
              inputProps={{
                  step: 300, // 5 min
              }}
              margin="normal"
              onChange={(e) => {
                const selectedTime = zonedTimeToUtc(
                  new Date(eventForm.date.toDateString() + ' ' + e.target.value),
                    'America/Lima'
                );
                setEventForm({
                    ...eventForm,
                    endTime: selectedTime,
                });
              }}
          /> 
          <TextField
              label="Descripción del Evento"
              fullWidth
              margin="normal"
              name='description'
              value={eventForm.description}
              onChange={(e) => setEventForm({ ...eventForm, description: e.target.value } )}
          />
          {clients && Array.isArray(clients.data) &&
            <Autocomplete
                id="client-selection"
                options={clients.data}
                getOptionLabel={(client) => `${client.name} - ${client.phoneNumber}`}
                value={
                  clients.data.find(client => client.clientId === eventForm.clientID) || null
                }
                onChange={(event, newValue) => {
                  setEventForm({ ...eventForm, clientID: newValue ? newValue.clientId : null } )
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
          }

          { eventTypes && Array.isArray(eventTypes.data) && 
            <Autocomplete
                id="event-type-selection"
                options={eventTypes.data}
                getOptionLabel={(option) => option.name}
                value={
                  eventTypes.data.find(eventType => eventType.eventTypeID === eventForm.eventTypeID) || null
                }
                onChange={(event, newValue) => {
                  setEventForm({ ...eventForm, eventTypeID: newValue ? newValue.eventTypeID : null } )
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
          }
      </DialogContent>
      <DialogActions>
          <Button onClick={handleAddEventClose}>Cancelar</Button>
          <Button onClick={handleSaveEvent}>Guardar</Button>
      </DialogActions>
    </Dialog>
  )
}