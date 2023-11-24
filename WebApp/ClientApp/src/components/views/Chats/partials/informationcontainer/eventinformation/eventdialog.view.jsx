import React, { useEffect } from "react";
import EventDialogView from "../../../../Events/eventdialog.view";
import { EventInformationForm } from "../../../../../common/interface";
import { IconButton } from "@mui/material";
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';

export default function EventDialogView_({event}){
  const [open, setOpen] = React.useState(false);
  const [eventForm, setEventForm] = React.useState(EventInformationForm);

  
  const handleClickOpen = () => {
    if (event) {
      const dateAssigned = event.dateAssigned;
      const startTimeComponents = event.beginTime ? event.beginTime.split(':') : [];
      const endTimeComponents = event.endTime ? event.endTime.split(':') : [];

      
      const startTime = new Date(
          dateAssigned + 'T' +
          startTimeComponents.join(':')
      );

      const endTime = new Date(
          dateAssigned + 'T' +
          endTimeComponents.join(':')
      );

      setEventForm({
          eventID: event.eventID || null,
          clientID: event.client.personID || null,
          eventID: event.eventID || null,
          title: event.title || '',
          description: event.description || '',
          date: startTime || new Date(),
          startTime: startTime || new Date(),
          endTime: endTime || new Date(),
          eventTypeID: event.status?.eventTypeID || null
      });
      console.log(event);
    }
    setOpen(true);
}

  return (
    <React.Fragment>
      <IconButton aria-label="Calendario" size="small" onClick={handleClickOpen}>
        <CalendarMonthIcon fontSize='inherit' sx={{fontSize:"16px",color:"#000"}}/>
      </IconButton>
      <EventDialogView open={open} setOpen={setOpen} event={{eventForm, setEventForm}}/>
    </React.Fragment>
  )

}