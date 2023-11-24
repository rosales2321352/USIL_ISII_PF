import React from 'react';
import {Box,Card,Typography} from '@mui/material';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import FindInPageOutlinedIcon from '@mui/icons-material/FindInPageOutlined';
export default function EventCardView({event}){
  

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

  return(
    <Box sx={{mt:1}}>
      <Card elevation={1} sx={{p:1}}>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
          <Box>
            <CalendarMonthIcon sx={{fontSize:"16px"}}/>
            <Typography sx={{fontSize:"14px",ml:1}} component={"span"}>{event.title}</Typography>
          </Box>
          <FindInPageOutlinedIcon sx={{fontSize:"16px"}}/>
        </Box>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between",mt:1}}>
          <Typography sx={{fontSize:"12px"}}>{formatDate(event.dateAssigned)}</Typography>
          <Typography sx={{fontSize:"12px"}}>{convertTo12HourFormat(event.beginTime)} - {convertTo12HourFormat(event.endTime)}</Typography>
        </Box>
      </Card>
    </Box>
  )

}