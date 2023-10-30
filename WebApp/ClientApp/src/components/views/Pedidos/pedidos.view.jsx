import React, { Component } from 'react';
import { Button, Container, Typography, Grid, Paper, Divider, IconButton } from '@mui/material';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { Dialog, DialogTitle, DialogContent } from '@mui/material';
import { Link } from 'react-router-dom';
import AddIcon from '@mui/icons-material/Add';

export class PedidosView extends Component {
    static displayName = PedidosView.name;

    onDragEnd = (result) => {
        const { source, destination } = result;

        if (!destination) return;

        const columnsCopy = [...this.state.columns];
        const [movedUser] = columnsCopy[source.droppableId].users.splice(source.index, 1);

        if (source.droppableId === destination.droppableId) {
            columnsCopy[destination.droppableId].users.splice(destination.index, 0, movedUser);
        } else {
            columnsCopy[destination.droppableId].users.splice(destination.index, 0, movedUser);
        }

        this.setState({ columns: columnsCopy });
    }
    addContact = () => {
        const newContact = `Contacto ${this.state.columns[0].users.length + 1}`;
        const columnsCopy = [...this.state.columns];
        columnsCopy[0].users.push(newContact);
        this.setState({ columns: columnsCopy });
    }

    // 1. Añade el estado para el modal
    state = {
        // ... (estado existente)
        isModalOpen: false,
        selectedContact: null,
    };

    // 2. Implementa el método para abrir el modal
    openModal = (contact) => {
        this.setState({
            isModalOpen: true,
            selectedContact: contact,
        });
    };

    // 3. Implementa el método para cerrar el modal
    closeModal = () => {
        this.setState({
            isModalOpen: false,
            selectedContact: null,
        });
    };

    constructor(props) {
        super(props);
        this.state = {
            columns: [
                { title: 'Prospecto', users: ['Contacto 1', 'Contacto 2', 'Contacto 3', 'Contacto 4', 'Contacto 5', 'Contacto 6', 'Contacto 7', 'Contacto 8', 'Contacto 9', 'Contacto 10', 'Contacto 11', 'Contacto 12', 'Contacto 13', 'Contacto 14'] },
                { title: 'Orden de Compra', users: ['Contacto 15'] },
                { title: 'Finalizado', users: [] },
                { title: 'Cancelado', users: ['Contacto 16', 'Contacto 17', 'Contacto 18'] },
            ]
        };
    }

    render() {
        
        const titleStyle = {
            height: '50px',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            marginBottom: 5,
            backgroundColor: 'white', // Color de fondo naranja para el título
            color: 'orange', // Color de texto blanco para el título
            fontSize: '1.5rem',
            fontWeight: 'bold'
        };

        return (
            <DragDropContext onDragEnd={this.onDragEnd}>

                <Container style={{ marginTop: 40 }}>
                    <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', marginBottom: 10, color: 'ffa726' }}>
                        <Typography variant="h2" style={{ fontWeight: 'bold', color: 'orange' }}>
                            Pedidos
                        </Typography>

                    </div>
                    <div style={{ display: 'flex', alignItems: 'center', marginBottom: 20 }}>
                        <IconButton sx={{
                            fontSize: 30,
                            color: '#fff',
                            backgroundColor: '#ffa726', 
                            boxShadow: '0 0 5px rgba(0, 0, 0, 0.3)',
                            '&:hover': {
                                backgroundColor: '#ff8c00',    // Cambiamos a una tonalidad más oscura de naranja al hacer hover
                                boxShadow: '0 0 8px rgba(0, 0, 0, 0.4)'
                            }
                        }} onClick={this.addContact}>
                            <AddIcon />
                        </IconButton>
                    </div>
                    <Grid container spacing={3}>
                        {this.state.columns.map((column, columnIndex) => (
                            <Grid item xs={3} key={columnIndex}>
                                <Paper elevation={10} style={{ padding: 15, height: '600px', minHeight: '100px', overflowY: 'auto' }}>

                                    <div style={titleStyle}>
                                        <Typography variant="h6">
                                            {column.title}
                                        </Typography>
                                    </div>

                                    <Divider style={{ marginBottom: 10, backgroundColor: 'orange', height: '4px' }} />

                                    <Droppable droppableId={String(columnIndex)} key={columnIndex}>
                                        {(provided) => (
                                            <div
                                                ref={provided.innerRef}
                                                {...provided.droppableProps}
                                                style={{ minHeight: '500px' }}
                                            >
                                                {column.users.map((user, userIndex) => (
                                                    <Draggable key={user} draggableId={user} index={userIndex}>
                                                        {(provided) => (
                                                            <Paper
                                                                ref={provided.innerRef}
                                                                {...provided.draggableProps}
                                                                {...provided.dragHandleProps}
                                                                style={{ ...provided.draggableProps.style, padding: 10, marginBottom: 10, backgroundColor: 'white' }}
                                                                onClick={() => this.openModal(user)}
                                                            >
                                                                {user}
                                                            </Paper>
                                                        )}
                                                    </Draggable>
                                                ))}
                                                {provided.placeholder}
                                            </div>
                                        )}
                                    </Droppable>

                                </Paper>

                                <Button
                                    variant="text"
                                    color="warning"
                                    style={{ marginTop: 10, display: 'block', textAlign: 'center' }}
                                    component={Link}
                                    to={`/${column.title.replace(/\s+/g, '-').toLowerCase()}`}
                                >
                                    Ver más
                                </Button>
                            </Grid>
                        ))}
                    </Grid>

                </Container>
                <Dialog open={this.state.isModalOpen} onClose={this.closeModal}>
                    <DialogTitle>{this.state.selectedContact}</DialogTitle>
                    <DialogContent>
                        Aquí puedes añadir el contenido que desees mostrar en el modal.
                    </DialogContent>
                </Dialog>
            </DragDropContext>
        );
    }
}
