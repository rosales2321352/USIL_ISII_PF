import React from 'react';
import {Box,Card,Typography} from '@mui/material';
import NoteAltOutlinedIcon from '@mui/icons-material/NoteAltOutlined';
import FindInPageOutlinedIcon from '@mui/icons-material/FindInPageOutlined';
import NoteDialogView from './notedialog.view';

export default function NoteCardView({note}) {
  return (
    <Box sx={{mt:1}}>
      <Card elevation={1} sx={{p:1}}>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
          <Box>
            <NoteAltOutlinedIcon sx={{fontSize:"16px"}}/>
            <Typography sx={{fontSize:"14px",ml:1}} component={"span"}>{note.title}</Typography>
          </Box>
          <NoteDialogView note={note}/>
        </Box>
        <Box >
          <Typography 
          sx={{
            fontSize:"12px",
            display:"-webkit-box",
            WebkitBoxOrient:"vertical",
            WebkitLineClamp:"3",
            overflow:"hidden",
          }} 
          component={"span"}>{note.description}</Typography>
        </Box>
      </Card>
    </Box>
  )
}