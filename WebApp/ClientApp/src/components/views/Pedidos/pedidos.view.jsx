import React, { Component } from 'react';
import { Button, Container, Typography, Grid, Paper, Divider, IconButton, TextField } from '@mui/material';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import { Link } from 'react-router-dom';
import AddIcon from '@mui/icons-material/Add';
import Autocomplete from '@mui/material/Autocomplete';
import HistoryIcon from '@mui/icons-material/History';


const statusToColumnIndex = {
    1: 0, // Prospecto
    2: 1, // Orden de Compra
    3: 3, // Cancelado
    4: 2  // Finalizado
};

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
            const newStatusID = statusToColumnIndex[parseInt(destination.droppableId) + 1] + 1; // Suponemos que el droppableId empieza desde 0 y el orderStatusID desde 1
            this.updateOrderStatusOnServer(movedUser.draggableId, newStatusID);
        }

        this.setState({ columns: columnsCopy });
    }

    // Método para actualizar el estado del pedido en el servidor
    updateOrderStatusOnServer = async (orderID, newStatusID) => {
        const request = {
            orderID: parseInt(orderID),
            orderStatusID: parseInt(newStatusID),
            comment: "Sin Comentario"
        };

        try {
            const response = await fetch('api/Orders/edit', {
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
            const response = await fetch(`api/Orders/detail/${contact.draggableId}`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();

            this.setState({
                isModalOpen: true,
                selectedContact: contact,
                orderDetails: data.data, // Establecer los detalles del pedido en el estado
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
            selectedClientId: null,

            title: '',
            totalAmount: '',
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
                const columnIndex = statusToColumnIndex[order.status.orderStatusID];
                columns[columnIndex].users.push({
                    draggableId: String(order.orderID),
                    clientName: order.client.name,
                    creationDate: order.creationDate,
                    title: order.title,
                    totalAmount: order.totalAmount,
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
            const response = await fetch('api/clients/all');
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
        const { selectedClientId, title, totalAmount } = this.state;

        const requestBody = {
            title: title,
            totalAmount: parseFloat(totalAmount),
            clientID: selectedClientId,
            sellerID: 1  // Puedes cambiar esto si el ID del vendedor varía
        };

        try {
            const response = await fetch('api/Orders/create', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(requestBody)
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const text = await response.text();
            if (text === "ok") {
                console.log("Pedido creado exitosamente.");
                this.loadData();
                this.closeAddModal();  // Cierra el modal una vez que el pedido ha sido creado
                // Aquí puedes agregar lógica para actualizar tus pedidos o cualquier otra operación posterior
            } else {
                console.error("Error al crear el pedido:", text);
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

                <Container style={{ marginTop: 10 }}>
                    <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', marginBottom: 10, color: 'ffa726' }}>
                        <Typography variant="h2" style={{ fontWeight: 'bold', color: 'orange' }}>
                            Pedidos
                        </Typography>

                    </div>
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 20 }}>
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
                        <Link to="/historialPedidos">
                            <IconButton
                                sx={{
                                    fontSize: 30,
                                    color: '#fff',
                                    backgroundColor: '#3f51b5',    // Color azul como ejemplo
                                    marginLeft: 10,                // Margen izquierdo para separarlo del otro ícono
                                    boxShadow: '0 0 5px rgba(0, 0, 0, 0.3)',
                                    '&:hover': {
                                        backgroundColor: '#283593',  // Un tono de azul más oscuro al hacer hover
                                        boxShadow: '0 0 8px rgba(0, 0, 0, 0.4)'
                                    }
                                }}
                                onClick={this.navigateToHistory}   // Función que te llevará a la vista de historial
                            >
                                <HistoryIcon />
                            </IconButton>
                        </Link>
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
                                                                    <div>Pedido: {user.title}</div>
                                                                    <div>Cliente: {user.clientName}</div>
                                                                    <div>Fecha: {user.creationDate}</div>
                                                                    <div>Monto: {user.totalAmount !== null ? user.totalAmount : 0}</div>
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
                                <p><strong>Order ID:</strong> {this.state.orderDetails.orderID}</p>
                                <p><strong>Fecha de creacion:</strong> {this.state.orderDetails.creationDate}</p>
                                <p><strong>Estado de Pedido:</strong> {this.state.orderDetails.status.name}</p>
                                <p><strong>Nombre del Cliente:</strong> {this.state.orderDetails.client.name}</p>
                                <p><strong>Celular:</strong> {this.state.orderDetails.client.phoneNumber}</p>
                                <p><strong>Ubicacion:</strong> {this.state.orderDetails.location}</p>
                                <p><strong>Direccion:</strong> {this.state.orderDetails.address}</p>
                            </div>
                        )}
                    </DialogContent>
                </Dialog>
                <Dialog open={this.state.isAddModalOpen} onClose={this.closeAddModal}>
                    <DialogTitle style={{ margin: 5 }}>Selecciona un cliente</DialogTitle>
                    <DialogContent >
                        <TextField
                            label="Título"
                            variant="outlined"
                            fullWidth
                            value={this.state.title}
                            onChange={e => this.setState({ title: e.target.value })}
                            margin="normal"
                        />
                        <TextField
                            label="Cantidad Total"
                            variant="outlined"
                            fullWidth
                            value={this.state.totalAmount}
                            onChange={e => this.setState({ totalAmount: e.target.value })}
                            margin="normal"
                        />
                        <Autocomplete
                            id="client-selection"
                            options={this.state.clients}
                            getOptionLabel={(client) => `${client.name} - ${client.phoneNumber}`}
                            value={
                                this.state.clients.find(client => client.personID === this.state.selectedClientId) || null
                            }
                            onChange={(event, newValue) => {
                                this.setState({ selectedClientId: newValue ? newValue.personID : null });
                            }}
                            renderInput={(params) => (
                                <TextField
                                    {...params}
                                    label="Selecciona un cliente"
                                    variant="outlined"
                                    margin="normal"
                                    fullWidth
                                />
                            )}
                        />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.closeAddModal} color="primary">
                            Cancelar
                        </Button>
                        <Button
                            onClick={this.handleAdd}
                            color="primary"
                            disabled={!this.state.selectedClientId || !this.state.title || !this.state.totalAmount}
                        >
                            Añadir
                        </Button>
                    </DialogActions>
                </Dialog>
            </DragDropContext>
        );
    }
}