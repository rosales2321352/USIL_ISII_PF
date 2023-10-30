import  { useState, createRef } from "react";
import {Box, IconButton} from "@mui/material";
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import NoteAltIcon from '@mui/icons-material/NoteAlt';
import InsertEmoticonIcon from '@mui/icons-material/InsertEmoticon';
import { Button } from "@mui/material";
import data from '@emoji-mart/data'
import Picker from '@emoji-mart/react'


export default function ChatToolsView(){
  const [openEmoji, setOpenEmoji] = useState(false);

  const textArea = createRef();
  const buttonEmoji = createRef();

  const handlerSelector = (e) => {

    let editor= textArea.current;
    let u = editor.value;
    let start = editor.selectionStart;
    let end = editor.selectionEnd;
    
  
    console.log([u.substring(0, start), u.substring(end), u.substring(start, end)]);
  }

  const handlerButton = (e) => {
    console.log(e)
  }

  const handlerOpenEmoji = (e) => {
    setOpenEmoji(true);
  }
  const handlerClose = (e) => {
    e.preventDefault();
    e.stopPropagation();
    let return_ = false;
    let button = document.getElementById("button-emoji");
    let editor = textArea.current;
    
    button.childNodes.forEach((el) => {
      if(el === e.target || el.contains(e.target) || e.target === button ||  e.target === editor ){
        return_ = true;
        return;
      }
    })

    if(return_){
      return;
    }
    setOpenEmoji(false);
  }

  return (
    <Box sx={{
      border: '1px solid #e0e0e0',
      height: "180px",
      borderRadius: '30px 30px 0 0',
      backgroundColor: 'white',
      position:"relative"
    }}>
      <Box sx={{height: "35px"}}>
        <Box sx={{border:"1px solid #e0e0e0", display:"flex", alignItems:"center", justifyContent:"end", p:1, pr:3}}>
          <IconButton aria-label="Notas" size="small">
            <NoteAltIcon fontSize="inherit"/>
          </IconButton>
          <IconButton aria-label="Calendario" size="small">
            <CalendarMonthIcon fontSize="inherit"/>
          </IconButton>
        </Box>
      </Box>
      <Box sx={{height: "calc(100% - 75px)"}}>
        <textarea ref={textArea}  className="textarea-chat"  placeholder="Escribe un mensaje" />
      </Box>
      <Box sx={{height: "40px",pl:1,display:"flex", alignItems:"center", justifyContent:"space-between  "}}>
        <Box sx={{width:"100%"}}>
          {openEmoji  &&
          <Box sx={{position:"absolute",left:0,bottom:'calc(100% - 40px)'}}>
            <Picker 
            data={data} 
            onEmojiSelect={handlerButton} 
            onClickOutside={handlerClose}
            theme="light"
            locale="es"
            />
          </Box>}
          <IconButton aria-label="Calendario" size="small" id="button-emoji" ref={buttonEmoji} onClick={handlerOpenEmoji}>
            <InsertEmoticonIcon fontSize="inherit"/>
          </IconButton>
        </Box>
        

      </Box>
    </Box>
  )

}