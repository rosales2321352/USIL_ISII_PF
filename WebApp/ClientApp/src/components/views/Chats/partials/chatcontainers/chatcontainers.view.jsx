import { Box } from "@mui/material";
import bg_wat from "../../../../../assets/img/bg_watt.webp";

export default function ChatContainersView(){
  return (
    <Box sx={{
      position: 'relative',
      height: '100%',
      backgroundImage: `url(${bg_wat})`,
      backgroundSize: 'fill',
      backgroundPosition: 'center',
    }}>
      <Box sx={{
        border: '1px solid #e0e0e0',
        height: "120px",
        borderRadius: '0 0 30px 30px',
        backgroundColor: 'white',
      }}>1</Box>
      <Box sx={{
        height: "calc(100% - 300px)"
      }}>2</Box>
      <Box sx={{
        border: '1px solid #e0e0e0',
        height: "180px",
        borderRadius: '30px 30px 0 0',
        backgroundColor: 'white',
      }}>3</Box>
    </Box>
  )
}