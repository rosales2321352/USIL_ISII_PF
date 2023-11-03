import React, { Component } from 'react';
import { Table, TableBody, TableCell, TableHead, TableRow, Paper, Select, TextField, IconButton, Typography, Container, Button } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import WhatsAppIcon from '@mui/icons-material/WhatsApp';
import InfoIcon from '@mui/icons-material/Info';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

export class ProspectoView extends Component {
    static displayName = ProspectoView.name;

    handleChange = (index, event) => {
        const newRows = [...this.rows];
        newRows[index].estado = event.target.value;
        this.setState({ rows: newRows });
    }

    constructor(props) {
        super(props);
        this.state = {
            data: [],  // Almacenará los datos de la API
            error: null,  // Almacenará un mensaje de error en caso de que haya alguno
            searchTerm: '',  // Para el buscador
            orderBy: 'orderID',  // Por defecto, ordenaremos por orderID
            order: 'asc',  // Puede ser 'asc' o 'desc'
            isEditModalOpen: false,
            editData: null,
            isDetailModalOpen: false,
            orderDetails: null,
        };
    }

    async componentDidMount() {
        try {
            const response = await fetch('api/Orders/by-status/1');

            // Verificamos si la respuesta es válida
            if (!response.ok) {
                throw new Error("Error al obtener datos de la API");
            }
            
            const data = await response.json();
            this.setState({ data: data.data });
        } catch (error) {
            console.error(error);
            this.setState({ error: "Ocurrió un error al obtener los datos." });
        }
    }

    handleSort = (column) => {
        const isAsc = this.state.orderBy === column && this.state.order === 'asc';
        this.setState({
            orderBy: column,
            order: isAsc ? 'desc' : 'asc'
        });
    };

    handleOpenDetailModal = async (order) => {
        try {
            const response = await fetch(`api/Orders/detail/${order.orderID}`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();

            this.setState({
                isDetailModalOpen: true,
                orderDetails: data.data,
            });
        } catch (error) {
            console.error("Hubo un problema con la petición fetch:", error);
        }
    };


    handleOpenEditModal = (order) => {
        this.setState({
            isEditModalOpen: true,
            editData: {
                orderID: order.orderID,
                address: order.address,
                location: order.location,
                contactName: order.client.name,
                totalAmount: order.totalAmount,
                orderStatusID: 1,
            }
        });
    };

    handleCloseEditModal = () => {
        this.setState({ isEditModalOpen: false, editData: null });
    };

    handleEditOrder = async () => {
        try {
            const response = await fetch('api/Orders/edit', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(this.state.editData)
            });

            if (!response.ok) {
                throw new Error('Error al editar el pedido');
            }

            this.handleCloseEditModal();
            this.componentDidMount();  // Vuelve a cargar los datos

        } catch (error) {
            console.error(error);
            alert('Ocurrió un error al editar el pedido.');
        }
    };

    render() {
        const styles = {
            tableHeader: {
                backgroundColor: '#ffbb66',
                color: 'white',
                borderRight: '1px solid #e0e0e0',
            },
            tableCell: {
                boxShadow: '0px 2px 10px rgba(0, 0, 0, 0.05)',
                backgroundColor: 'white',
                borderRight: '1px solid #e0e0e0',
            },
            lastCell: { // Estilo para la última celda, sin borde derecho
                boxShadow: '0px 2px 10px rgba(0, 0, 0, 0.05)',
                backgroundColor: 'white',
            },
            select: {
                width: '100%', 
            }
        };
        const filteredData = this.state.data
            .filter(order =>
                order.client.name.toLowerCase().includes(this.state.searchTerm.toLowerCase())
                // Puedes agregar más campos aquí si necesitas filtrar por más datos
            )
            .sort((a, b) => {
                const isAsc = this.state.order === 'asc';
                if (a[this.state.orderBy] < b[this.state.orderBy]) {
                    return isAsc ? -1 : 1;
                }
                if (a[this.state.orderBy] > b[this.state.orderBy]) {
                    return isAsc ? 1 : -1;
                }
                return 0;
        });

        return (
            <Container >
                <div style={{
                    display: 'flex',
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    margin: 20,
                    padding: '0 10px'  // Añade padding a la derecha e izquierda
                }}>
                    <Typography variant="h2" style={{ fontWeight: 'bold', color: 'orange' }}>
                        Prospectos
                    </Typography>
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
                <div style={{
                    display: 'flex',
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    margin: 20,
                    padding: '0 10px'  // Añade padding a la derecha e izquierda
                }}>
                <TextField
                    label="Buscar por nombre del cliente"
                    fullWidth
                    value={this.state.searchTerm}
                    onChange={e => this.setState({ searchTerm: e.target.value })}
                    style={{ marginBottom: 20}}
                    />
                </div>
                <Paper elevation={3} style={{ margin: 20 }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell
                                    style={styles.tableHeader}
                                    onClick={() => this.handleSort('orderID')}
                                >
                                    N° PEDIDO
                                </TableCell>
                                <TableCell
                                    style={styles.tableHeader}
                                    onClick={() => this.handleSort('client.name')}
                                >
                                    CLIENTE
                                </TableCell>
                                <TableCell style={styles.tableHeader}>MONTO</TableCell>
                                <TableCell style={styles.tableHeader}>FECHA</TableCell>
                                <TableCell style={styles.tableHeader}>PEDIDO</TableCell>
                                <TableCell style={{ ...styles.tableHeader, width: '160px' }}>ACCIONES</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {filteredData.map((order, index) => (
                                <TableRow key={order.orderID}>
                                    <TableCell style={styles.tableCell}>{order.orderID}</TableCell>
                                    <TableCell style={styles.tableCell}>{order.client.name}</TableCell>
                                    <TableCell style={styles.tableCell}>{order.totalAmount !== null ? order.totalAmount : 0}</TableCell>
                                    <TableCell style={styles.tableCell}>{order.creationDate}</TableCell>
                                    <TableCell style={styles.tableCell}>{order.title}</TableCell>
                                    <TableCell style={{ width: '150px' }}>
                                        <IconButton color="primary" onClick={() => this.handleOpenEditModal(order)}>
                                            <EditIcon />
                                        </IconButton>
                                        <IconButton color="primary">
                                            <WhatsAppIcon />
                                        </IconButton>
                                        <IconButton color="primary" onClick={() => this.handleOpenDetailModal(order)}>
                                            <InfoIcon />
                                        </IconButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
                <Dialog open={this.state.isEditModalOpen} onClose={this.handleCloseEditModal}>
                    <DialogTitle>Editar Pedido</DialogTitle>
                    <DialogContent>
                        <DialogContentText style={{ margin: 5 }}>
                            Modifica los campos necesarios y guarda los cambios.
                        </DialogContentText>
                        <TextField
                            label="Address"
                            value={this.state.editData?.address || ''}
                            margin="normal"
                            onChange={(e) => this.setState({ editData: { ...this.state.editData, address: e.target.value } })}
                            fullWidth
                        />
                        <TextField
                            label="Location"
                            value={this.state.editData?.location || ''}
                            margin="normal"
                            onChange={(e) => this.setState({ editData: { ...this.state.editData, location: e.target.value } })}
                            fullWidth
                        />
                        <TextField
                            label="Amount"
                            value={this.state.editData?.totalAmount || 0}
                            margin="normal"
                            onChange={(e) => this.setState({ editData: { ...this.state.editData, totalAmount: parseFloat(e.target.value) } })}
                            fullWidth
                        />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleEditOrder}>Guardar cambios</Button>
                        <Button onClick={this.handleCloseEditModal}>Cancelar</Button>
                    </DialogActions>
                </Dialog>
                <Dialog open={this.state.isDetailModalOpen} onClose={() => this.setState({ isDetailModalOpen: false })}>
                    <DialogTitle>Order Details</DialogTitle>
                    <DialogContent>
                        <Typography variant="body1">Order ID: {this.state.orderDetails?.orderID}</Typography>
                        <Typography variant="body1">Nombre del cliente: {this.state.orderDetails?.client.name}</Typography>
                        <Typography variant="body1">Fecha de creacion:: {this.state.orderDetails?.creationDate}</Typography>
                        <Typography variant="body1">Celular: {this.state.orderDetails?.client.phoneNumber}</Typography>
                        <Typography variant="body1">Ubicacion: {this.state.orderDetails?.location}</Typography>
                        <Typography variant="body1">Direccion: {this.state.orderDetails?.address}</Typography>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={() => this.setState({ isDetailModalOpen: false })}>Close</Button>
                    </DialogActions>
                </Dialog>

            </Container>
        );
    }
}
