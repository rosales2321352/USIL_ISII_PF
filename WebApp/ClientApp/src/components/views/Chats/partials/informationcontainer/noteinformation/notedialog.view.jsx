import * as React from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import NoteContext from '../../../../../../context/Note/note.context';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import NoteAltIcon from '@mui/icons-material/NoteAlt';
import FindInPageOutlinedIcon from '@mui/icons-material/FindInPageOutlined';
import ReactQuill from 'react-quill';

import 'react-quill/dist/quill.snow.css';
import { NoteInformationForm } from '../../../../../common/interface';
import TypeAnnotationView from './partials/typeannotation.notedialog.view';
import { submitApi } from '../../../../../../hooks/useApi';

export default function NoteDialogView({note}) {

  const ClientContext_ = React.useContext(ClientContext);
  const NoteContext_ = React.useContext(NoteContext);
  const [open, setOpen] = React.useState(false);
  const [noteFormPrevious, setNoteFormPrevious] = React.useState(NoteInformationForm);
  const [noteForm, setNoteForm] = React.useState(NoteInformationForm);

  React.useEffect(() => {
    setNoteForm({
      annotationID:note?.annotationID || null,
      title:note?.title || '',
      description:note?.description || '',
      annotationTypeID: note?.type?.annotationTypeID || null
    });
    setNoteFormPrevious({
      annotationID:note?.annotationID || null,
      title:note?.title || '',
      description:note?.description || '',
      annotationTypeID: note?.type?.annotationTypeID || null
    });

  },[note])
    
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setNoteForm(noteFormPrevious);
    setOpen(false);
  };

  const handleSubmit = () => {
    if(noteForm.annotationID !== null){
      if(noteFormPrevious.title !== noteForm.title || noteFormPrevious.description !== noteForm.description || noteFormPrevious.annotationTypeID !== noteForm.annotationTypeID){
        submitApi({
          url: process.env.REACT_APP_URL_NOTE_UPDATE,
          options:{
            method: "PUT",
            body: JSON.stringify(noteForm)
          }
        }).catch((error) => {
          NoteContext_.setReload(!NoteContext_.reload);  
        });
      }
    }
    else{
      if(ClientContext_.current_client){
        if(noteForm.title !== '' && noteForm.description !== '' && noteForm.annotationTypeID !== null){
          submitApi({
            url: process.env.REACT_APP_URL_NOTE_CREATE,
            options:{
              method: "POST",
              body: JSON.stringify({
                ...noteForm,
                clientID: ClientContext_.current_client?.clientId || 0,
                sellerID: ClientContext_.current_client?.sellerID || 0
              })
            }
          }).catch((error) => {
            setNoteForm(NoteInformationForm);
            setNoteFormPrevious(NoteInformationForm);
            NoteContext_.setReload(!NoteContext_.reload);  
            setOpen(false);
          });
        }
      }
    }
  }

  

  return (
    <React.Fragment>
      <IconButton aria-label="Calendario" size="small" onClick={handleClickOpen}>
        {note ? <FindInPageOutlinedIcon fontSize='inherit'/>: <NoteAltIcon fontSize='inherit'/>}
      </IconButton>
      <Dialog
        open={open}
        onClose={handleClose}
        fullWidth={true}
        maxWidth={"md"}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          <input type="text" placeholder='Título' className='form-control-custom' name="title" value={noteForm.title} onChange={(e) => setNoteForm({...noteForm,title:e.target.value})} />
          <TypeAnnotationView typeAnnotationId={noteForm.annotationTypeID} form={{noteForm,setNoteForm}} />
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <ReactQuill theme="snow" value={noteForm.description} onChange={(e) => setNoteForm({...noteForm,description:e})} />
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} >
            Cancelar
          </Button>
          <Button onClick={handleSubmit} autoFocus>
            Guardar
          </Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
}

