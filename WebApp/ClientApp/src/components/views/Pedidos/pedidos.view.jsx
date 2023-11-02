import React, { Component } from 'react';
import { Button, Container, Typography, Grid, Paper, Divider, IconButton } from '@mui/material';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
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
            // Si el pedido ha sido movido a otra columna, actualiza el estado en el servidor
            const newStatusID = parseInt(destination.droppableId) + 1; // Suponemos que el droppableId empieza desde 0 y el orderStatusID desde 1
            this.updateOrderStatusOnServer(movedUser.draggableId, newStatusID);
        }

        this.setState({ columns: columnsCopy });
    }

    // Método para actualizar el estado del pedido en el servidor
    updateOrderStatusOnServer = async (orderID, newStatusID) => {
        const request = {
            comment: "Sin Comentario",
            orderID: parseInt(orderID), // Asegurarse de que es un número
            newStatusID: parseInt(newStatusID)
        };

        try {
            const response = await fetch('api/orders/update', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(request),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            // Aquí puedes manejar cualquier respuesta si es necesario
            const data = await response.json();
            console.log(data);

        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
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
            isAddModalOpen: false,
            selectedContact: null,
            orderDetails: null, // Agrega un estado para los detalles del pedido
            clients: [],
            selectedClientId: null
        };
    }
    
    // Realiza una sola solicitud para obtener todas las órdenes
    loadData = async () => {
        try {
            const response = await fetch(`api/Orders/all`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const responseData = await response.json();
            const data = responseData.data; // Usa la propiedad 'data' del nuevo formato


            // Organiza las órdenes según su estado en el estado local
            const columns = [
                { title: 'Prospecto', users: [] },
                { title: 'Orden de Compra', users: [] },
                { title: 'Finalizado', users: [] },
                { title: 'Cancelado', users: [] },
            ];

            data.forEach(order => {
                const columnIndex = order.status.orderStatusID - 1; // Usa la propiedad 'status' del nuevo formato
                columns[columnIndex].users.push({
                    draggableId: String(order.orderID),
                    clientName: order.client.name,  // Accede a la propiedad 'name' dentro de 'client'
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

    loadClients = async () => {
        try {
            const response = await fetch('api/Client/Lista');
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();
            this.setState({ clients: data });
        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
    }
    handleClientSelection = (id) => {
        this.setState({ selectedClientId: id });
    }

    openAddModal = () => {
        this.loadClients();  // Carga los clientes
        this.setState({ isAddModalOpen: true });
    }
    closeAddModal = () => {
        this.setState({ isAddModalOpen: false });
    }

    handleAdd = async () => {
        const { selectedClientId } = this.state;

        try {
            const response = await fetch('api/Orders/Guardar', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(selectedClientId)
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const data = await response.json();
            if (data === "ok") {
                console.log("Pedido creado exitosamente.");
                this.closeAddModal();  // Cierra el modal una vez que el pedido ha sido creado
                // Aquí puedes agregar lógica para actualizar tus pedidos o cualquier otra operación posterior
            } else {
                console.error("Error al crear el pedido:", data);
            }
        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
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
                        }} onClick={this.openAddModal}>
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
                <Dialog open={this.state.isAddModalOpen} onClose={this.closeAddModal}>
                    <DialogTitle>Selecciona un cliente</DialogTitle>
                    <DialogContent>
                        {this.state.clients.map(client => (
                            <div
                                key={client.personID}
                                style={{ padding: 10, cursor: 'pointer', backgroundColor: this.state.selectedClientId === client.personID ? '#e0e0e0' : 'transparent' }}
                                onClick={() => this.handleClientSelection(client.personID)}
                            >
                                {client.name} - {client.phoneNumber}
                            </div>
                        ))}
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.closeAddModal} color="primary">
                            Cancelar
                        </Button>
                        <Button
                            onClick={this.handleAdd}
                            color="primary"
                            disabled={!this.state.selectedClientId}
                        >
                            Añadir
                        </Button>
                    </DialogActions>
                </Dialog>
            </DragDropContext>
        );
    }
}