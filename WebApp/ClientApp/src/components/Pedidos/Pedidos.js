import React, { Component } from 'react';
import { Button, Container, Typography, Grid, Paper, Divider, IconButton } from '@mui/material';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { Dialog, DialogTitle, DialogContent } from '@mui/material';
import { Link } from 'react-router-dom';
import AddIcon from '@mui/icons-material/Add';

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

    // 2. Implementa el método para abrir el modal
    openModal = async (contact) => {
        try {
            // Hacer una solicitud al controlador para obtener los detalles del pedido
            const response = await fetch(`api/Order/Detalle/${contact.draggableId}`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();

            this.setState({
                isModalOpen: true,
                selectedContact: contact,
                orderDetails: data, // Establecer los detalles del pedido en el estado
            });
        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
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
                { title: 'Prospecto', users: [] },
                { title: 'Orden de Compra', users: [] },
                { title: 'Finalizado', users: [] },
                { title: 'Cancelado', users: [] },
            ],
            isModalOpen: false,
            selectedContact: null,
            orderDetails: null, // Agrega un estado para los detalles del pedido
        };
    }

    // Realiza una sola solicitud para obtener todas las órdenes
    loadData = async () => {
        try {
            const response = await fetch(`api/Order/Lista`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();

            // Organiza las órdenes según su estado en el estado local
            const columns = [
                { title: 'Prospecto', users: [] },
                { title: 'Orden de Compra', users: [] },
                { title: 'Finalizado', users: [] },
                { title: 'Cancelado', users: [] },
            ];

            data.forEach(order => {
                const columnIndex = order.orderStatusID - 1; // Suponiendo que el orderStatusID comienza en 1
                columns[columnIndex].users.push({
                    draggableId: String(order.orderID),
                    clientName: order.clientName,
                    creationDate: order.creationDate,
                });
            });

            this.setState({ columns });

        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
    }

    componentDidMount() {
        this.loadData();
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
                            <Grid key={columnIndex} item xs={3} >
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
                                                    <Draggable key={user.draggableId} draggableId={user.draggableId} index={userIndex}>
                                                        {(provided) => (
                                                            <Paper
                                                                ref={provided.innerRef}
                                                                {...provided.draggableProps}
                                                                {...provided.dragHandleProps}
                                                                style={{ ...provided.draggableProps.style, padding: 10, marginBottom: 10, backgroundColor: 'white' }}
                                                                onClick={() => this.openModal(user)}
                                                            >
                                                                <div>
                                                                    <div>Client Name: {user.clientName}</div>
                                                                    <div>Creation Date: {user.creationDate}</div>
                                                                </div>
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
                    <DialogTitle>{this.state.selectedContact && this.state.selectedContact.clientName}</DialogTitle>
                    <DialogContent>
                        {this.state.orderDetails && (
                            <div>
                                <div>Creation Date: {this.state.orderDetails.creationDate}</div>
                                <div>Client Phone: {this.state.orderDetails.clientPhone}</div>
                                <div>Order Status: {this.state.orderDetails.orderName}</div>
                                <div>Address: {this.state.orderDetails.address}</div>
                                <div>Location: {this.state.orderDetails.location}</div>
                                <div>Contact Name: {this.state.orderDetails.contactName}</div>
                            </div>
                        )}
                    </DialogContent>
                </Dialog>

            </DragDropContext>
        );
    }
}