import { Box } from "@mui/material";
import { Outlet } from "react-router-dom";

export default function MainLayout() {
  return (
    <Box sx={{
      bgcolor: '#f5f5f7', 
      height: '100vh', 
      width: '100%', 
      position: 'relative',
      display: 'flex',
      justifyContent: 'space-between',
      alignItems: 'center',
      }}>
      <Box sx={{
        border: '1px solid #e0e0e0',
        width: '200px',
        height: '100vh',
      }} >Hola</Box>
      <Box sx={{
        border: '1px solid #e0e0e0',
        width: 'calc(100vw - 200px)',
        height: '100vh',
      }}>
        <Box sx={{
          height: '50px',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'end',
        }}>Hola1</Box>
        <Box sx={{
          height: 'calc(100vh - 60px)',
          overflow: 'auto',
        }}>
          <Outlet/>
        </Box>
      </Box>
    </Box>
  );
}