import  { useState, createRef, useContext, useEffect } from "react";
import ClientContext from "../../../../../../context/Client/client.context";
import MessageContext from "../../../../../../context/Message/message.context";
import {Box, IconButton} from "@mui/material";
import NoteAltIcon from '@mui/icons-material/NoteAlt';
import InsertEmoticonIcon from '@mui/icons-material/InsertEmoticon';
import { Button } from "@mui/material";
import data from '@emoji-mart/data'
import Picker from '@emoji-mart/react'
import SendIcon from '@mui/icons-material/Send';
import NoteDialogView from "../../informationcontainer/noteinformation/notedialog.view";
import EventDialogView_ from "../../informationcontainer/eventinformation/eventdialog.view";
import useApi, { submitApi } from "../../../../../../hooks/useApi";


export default function ChatToolsView(){
  const ClientContext_ = useContext(ClientContext);
  const MessageContext_ = useContext(MessageContext);
  const [conversation, setConversation] = useState({});
  useEffect(() => {
    if(ClientContext_.current_client.clientId){
      submitApi({
        url: "https://localhost:44445/api/conversations/details/"+ ClientContext_.current_client.clientId,
        options:{
          method: "GET",
        }
      }).then((data) => {
        if(data && data.statusCode === 200){
          setConversation(data.data);
        }
      })
    }      
  },[ClientContext_.current_client])

  const [openEmoji, setOpenEmoji] = useState(false);
  const [selector,setSelector] = useState({
    before: "",
    after: ""
  });
  const [emojis, setEmojis] = useState("");

  const textArea = createRef();
  const buttonEmoji = createRef();

  const handlerSelector = (e) => {

    let editor= textArea.current;
    let u = editor.value;
    let start = editor.selectionStart;
    let end = editor.selectionEnd;
    setEmojis("");
    setSelector({
      before: u.substring(0, start),
      after: u.substring(end)
    })
  }

  const handlerButton = (e) => {
    setEmojis(emojis+e.native);
    let newText = selector.before + emojis+e.native + selector.after;
    textArea.current.value = newText;
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

  const handlerSendMessage = () => {
    let editor = textArea.current;
    if(!editor.value || !conversation.conversationID){
      return;
    }
    let textMessage= {
      conversationID: conversation.conversationID,
      phoneNumber: ClientContext_.current_client.phoneNumber,
      text: editor.value
    }

    fetch("https://localhost:44445/api/texts/send", {
      method: "POST",
      headers: {
          'Content-Type': 'application/json',
      },
      body: JSON.stringify(textMessage)
    })
      .then(response => {
          if (!response.ok) {
              throw new Error(`HTTP error! Status: ${response.status}`);
          }
          MessageContext_.setReload(!MessageContext_.reload);
      })
      .catch(error => {
          console.error("Hubo un problema con la petición fetch:", error);
      }).finally(() => {
        editor.value = "";
      });
  }

  return (
    <>
    <Box sx={{
      border: '1px solid #e0e0e0',
      height: "150px",
      borderRadius: '30px 30px 0 0',
      backgroundColor: 'white',
      position:"relative"
    }}>
      <Box sx={{height: "35px"}}>
        <Box sx={{border:"1px solid #e0e0e0", display:"flex", alignItems:"center", justifyContent:"end", p:1, pr:3}}>
          <NoteDialogView note={null}/>
          <EventDialogView_ event={null}/>
          {/* <IconButton aria-label="Calendario" size="small">
            <CalendarMonthIcon fontSize="inherit"/>
          </IconButton> */}
        </Box>
      </Box>
      <Box sx={{height: "calc(100% - 75px)"}}>
        <textarea ref={textArea} onBlur={handlerSelector} className="textarea-chat"  placeholder="Escribe un mensaje" />
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
        <Box>
          <Button variant="contained" size="small" 
          sx={{
            fontSize: 10,
            pt:1,pb:1,
            mr:2,mb:1
          }} onClick={handlerSendMessage} >
            <SendIcon sx={{fontSize:"15px"}} />
          </Button>
        </Box>

      </Box>
    </Box>
    </>
  )

}