import React, { Component } from 'react';
import { Button, Container, Typography, Grid, Paper, Divider } from '@mui/material';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';

export class Pedidos extends Component {
    static displayName = Pedidos.name;

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
                        <Button variant="outlined" color="primary" onClick={this.addContact}>
                            Añadir Pedido a Prospecto
                        </Button>
                    </div>
                    <Grid container spacing={3}>
                        {this.state.columns.map((column, columnIndex) => (
                            <Droppable droppableId={String(columnIndex)} key={columnIndex}>
                                {(provided) => (
                                    <Grid item xs={3} ref={provided.innerRef} {...provided.droppableProps}>
                                        <Paper elevation={10} style={{ padding: 15, height: '600px', overflowY: 'auto' }}>
                                            <div style={titleStyle}>
                                                <Typography variant="h6">
                                                    {column.title}
                                                </Typography>
                                            </div>
                                            <Divider style={{ marginBottom: 10, backgroundColor: 'orange', height: '4px' }} />
                                            {column.users.map((user, userIndex) => (
                                                <Draggable key={user} draggableId={user} index={userIndex}>
                                                    {(provided) => (
                                                        <Paper
                                                            ref={provided.innerRef}
                                                            {...provided.draggableProps}
                                                            {...provided.dragHandleProps}
                                                            style={{ ...provided.draggableProps.style, padding: 10, marginBottom: 10, backgroundColor: 'white' }}>
                                                            {user}
                                                        </Paper>
                                                    )}
                                                </Draggable>
                                            ))}
                                            {provided.placeholder}
                                        </Paper>
                                    </Grid>
                                )}
                            </Droppable>
                        ))}
                    </Grid>
                </Container>
            </DragDropContext>
        );
    }
}
