// EventView.js
import React, { useState } from 'react';
import { Button, Grid, TextField, Typography } from '@mui/material';

const EventView = ({ selectedClientId }) => {
  const [selectedDate, setSelectedDate] = useState(null);
  const [startTime, setStartTime] = useState('');
  const [endTime, setEndTime] = useState('');

  const handleDateChange = (date) => {
    setSelectedDate(date);
  };

  const handleStartTimeChange = (event) => {
    setStartTime(event.target.value);
  };

  const handleEndTimeChange = (event) => {
    setEndTime(event.target.value);
  };

  const handleScheduleEvent = () => {
    // Aquí puedes implementar la lógica para guardar el evento en tu backend
    console.log('Cliente ID:', selectedClientId);
    console.log('Fecha:', selectedDate);
    console.log('Hora de inicio:', startTime);
    console.log('Hora final:', endTime);
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <Typography variant="h5">Agendar Evento para Cliente ID: {selectedClientId}</Typography>
      </Grid>
      <Grid item xs={12}>
        <TextField
          id="date"
          label="Fecha"
          type="date"
          InputLabelProps={{ shrink: true }}
          onChange={(e) => handleDateChange(e.target.value)}
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          id="start-time"
          label="Hora de inicio"
          type="time"
          InputLabelProps={{ shrink: true }}
          inputProps={{ step: 300 }}
          onChange={handleStartTimeChange}
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          id="end-time"
          label="Hora final"
          type="time"
          InputLabelProps={{ shrink: true }}
          inputProps={{ step: 300 }}
          onChange={handleEndTimeChange}
        />
      </Grid>
      <Grid item xs={12}>
        <Button variant="contained" color="primary" onClick={handleScheduleEvent}>
          Agendar Evento
        </Button>
      </Grid>
    </Grid>
  );
};

export default EventView;
