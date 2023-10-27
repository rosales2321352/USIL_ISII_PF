import { Box, TextField, Button } from "@mui/material";
import PaginationLayout from "../../../../layouts/pagination/pagination.layout";


export default function ContactListView(){
  return (
    <Box sx={{
      p:1,
      height: '100%',
    }}>
      <Box sx={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        height: '40px',
      }}>
        <TextField id="search-form-contact-list" label="Buscar Contacto" variant="outlined" size="small" sx={{
          mr:1,
          fontSize: 10,
        }}/>
        <Button variant="contained" >Buscar</Button>
      </Box>
      <Box sx={{
        height: 'calc(100% - 80px)',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
      }}>Hola</Box>
      <Box sx={{
        height: '40px',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
      }}>
        <PaginationLayout/>
      </Box>
    </Box>
  );
}