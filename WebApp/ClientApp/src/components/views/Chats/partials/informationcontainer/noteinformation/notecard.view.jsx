import React from 'react';
import {Box,Card,Typography} from '@mui/material';
import NoteAltOutlinedIcon from '@mui/icons-material/NoteAltOutlined';
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import NoteDialogView from './notedialog.view';
import IconButton from '@mui/material/IconButton';
import NoteContext from '../../../../../../context/Note/note.context';
import { submitApi } from '../../../../../../hooks/useApi';

export default function NoteCardView({note}) {
  
  const NoteContext_ = React.useContext(NoteContext);

  const handlerDelete = () => {
    if(note.annotationID){
      let confirmation = new Promise((resolve, reject) => {
        resolve(window.confirm("¿Deseas borrar esta nota?"))
      });
      confirmation.then((result) => {
        if(result){
          submitApi({
            url: process.env.REACT_APP_URL_NOTE_DELETE,
            options:{
              method: "DELETE",
              body: JSON.stringify({
                annotationID:note.annotationID
              })
            }
          }).catch((error) => {
            NoteContext_.setReload(!NoteContext_.reload);  
          });
        }
      })
    }
  }

  return (
    <Box sx={{mt:1}}>
      <Card elevation={1} sx={{p:1}}>
        <Box sx={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
          <Box>
            <NoteAltOutlinedIcon sx={{fontSize:"16px"}}/>
            <Typography sx={{fontSize:"14px",ml:1}} component={"span"}>{note.title}</Typography>
          </Box>
          <Box>
            <NoteDialogView note={note}/>
            <IconButton aria-label="Calendario" size="small" onClick={handlerDelete} >
              <DeleteOutlineIcon fontSize='small'/>
            </IconButton>
          </Box>
        </Box>
        <Box >
          <Typography 
          sx={{
            fontSize:"12px",
            display:"-webkit-box",
            WebkitBoxOrient:"vertical",
            WebkitLineClamp:"3",
            overflow:"hidden"
          }} 
          component={"span"}>
            <div className='note' dangerouslySetInnerHTML={{ __html: note.description }} />
          </Typography>
        </Box>
      </Card>
    </Box>
  )
}