import { Box,Avatar } from "@mui/material";
import ChatHeaderView from "./partials/chatheader.view";
import bg_wat from "../../../../../assets/img/bg_watt.webp";
import ChatToolsView from "./partials/chattools.view";

export default function ChatContainersView(){
  return (
    <Box sx={{
      position: 'relative',
      height: '100%',
      backgroundImage: `url(${bg_wat})`,
      backgroundSize: 'fill',
      backgroundPosition: 'center',
    }}>
      <ChatHeaderView/>
      <Box sx={{
        height: "calc(100% - 300px)"
      }}>2</Box>
      <ChatToolsView/>
    </Box>
  )
}