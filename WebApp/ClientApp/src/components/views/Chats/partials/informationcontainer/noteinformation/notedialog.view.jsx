import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import FindInPageOutlinedIcon from '@mui/icons-material/FindInPageOutlined';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

export default function NoteDialogView({note}) {
  const [open, setOpen] = React.useState(false);
  const [value, setValue] = React.useState('');
    
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };




  return (
    <React.Fragment>
      <Button variant="text" size='small' sx={{p:0}}  onClick={handleClickOpen}>
        <FindInPageOutlinedIcon sx={{fontSize:"16px"}}/>
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        fullWidth={true}
        maxWidth={"md"}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {note.title}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <ReactQuill theme="snow" value={value} onChange={setValue} />
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} autoFocus>
            Aceptar
          </Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
}

