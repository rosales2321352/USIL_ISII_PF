import React from 'react';
import { Box, List, ListItem, ListItemButton, ListItemText } from '@mui/material';
import { Link } from 'react-router-dom';
import logo from '../../assets/img/logo.png';

const NavBar = () => {
    return (

        <Box sx={{ border: '1px solid #e0e0e0', width: '200px', height: '100vh' }}>
            <img src={logo} alt="WZPCRM Logo" style={{ width: 'auto', height: '190px' }} /> 
            <div >   </div>
            <List>
                <ListItem disablePadding>
                    <ListItemButton component={Link} to="/pedidos">
                        <ListItemText primary="Pedidos" />
                    </ListItemButton>
                </ListItem>
                <ListItem disablePadding>
                    <ListItemButton component={Link} to="/chat">
                        <ListItemText primary="Chats" />
                    </ListItemButton>
                </ListItem>
                <ListItem disablePadding>
                    <ListItemButton component={Link} to="/contactos">
                        <ListItemText primary="Contactos" />
                    </ListItemButton>
                </ListItem>
            </List>
        </Box>
    );
};

export default NavBar;