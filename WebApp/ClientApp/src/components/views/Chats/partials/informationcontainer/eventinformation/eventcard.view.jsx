import React from 'react';
import EventContext from '../../../../../../context/Event/event.context';
import {Box,Card,IconButton,Typography} from '@mui/material';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import EventDialogView_ from './eventdialog.view';
export default function EventCardView({event}){
  const EventContext_ = React.useContext(EventContext);

  const formatDate = (date) => {
    const d = new Date(date);
    const optionsSpanish = { weekday: 'long', day: 'numeric', month: 'short' };
    const shortDateString = d.toLocaleDateString('es-ES', optionsSpanish);
    return shortDateString;
  }

  function convertTo12HourFormat(time24) {
    const [hours, minutes, seconds] = time24.split(':');
    const hours12 = (hours % 12) || 12;
    const period = hours < 12 ? 'AM' : 'PM';
    const time12 = `${hours12}:${minutes} ${period}`;
    return time12;
  }

  const handlerDelete = () => {

    if (event && event.eventID) {
      let confirmation = new Promise((resolve, reject) => { 
        resolve(window.confirm("¿Deseas borrar este evento?"))
      });
      confirmation.then((result) => {
        if(result){
          fetch(`api/Events/delete`, {
              method: 'DELETE',
              headers: {
                  'Content-Type': 'application/json',
              },
              body: JSON.stringify({ eventID: event.eventID }),
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
              })
              .catch(error => {
                  console.error("Hubo un problema con la petición fetch:", error);
              });
          }
        });
    }
  }

  return(
    <Box sx={{mt:1}}>
      <Card elevation={1} sx={{p:1}}>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
          <Box>
            <CalendarMonthIcon sx={{fontSize:"16px"}}/>
            <Typography sx={{fontSize:"14px",ml:1}} component={"span"}>{event.title}</Typography>
          </Box>
          <Box>
            <EventDialogView_ event={event} />
            <IconButton aria-label="Calendario" size="small" onClick={handlerDelete} >
              <DeleteOutlineIcon sx={{fontSize:"16px",color:"#000"}}/>
            </IconButton>
          </Box>
          {/* <FindInPageOutlinedIcon sx={{fontSize:"16px"}}/> */}
        </Box>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between",mt:1}}>
          <Typography sx={{fontSize:"12px"}}>{formatDate(event.dateAssigned)}</Typography>
          <Typography sx={{fontSize:"12px"}}>{convertTo12HourFormat(event.beginTime)} - {convertTo12HourFormat(event.endTime)}</Typography>
        </Box>
      </Card>
    </Box>
  )

}