import { Box } from "@mui/material";
import ChatHeaderView from "./partials/chatheader.view";
import bg_wat from "../../../../../assets/img/bg_watt.webp";
import ChatToolsView from "./partials/chattools.view";
import ChatMessagesView from "./partials/chatmesages.view";

export default function ChatContainersView() {



  return (
    <Box sx={{
      position: 'relative',
      height: '100%',
      backgroundImage: `url(${bg_wat})`,
      backgroundSize: 'fill',
      backgroundPosition: 'center',
    }}>
      <ChatHeaderView />
      <ChatMessagesView />
      <ChatToolsView />
    </Box>
  )
}