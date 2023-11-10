import React, { Component } from 'react';
import { Table, TableBody, TableCell, TableHead, TableRow, Paper, Select, TextField, IconButton, Typography, Container, Button, Box } from '@mui/material';
import { DragDropContext } from 'react-beautiful-dnd';
import AddIcon from '@mui/icons-material/Add';
import HistoryIcon from '@mui/icons-material/History';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import { EventBarView } from "../Events/eventBar.view";

export class HistorialPedidos extends Component {
    static displayName = HistorialPedidos.name;
    handleChange = (index, event) => {
        const newRows = [...this.rows];
        newRows[index].estado = event.target.value;
        this.setState({ rows: newRows });
    }

    constructor(props) {
        super(props);
        this.state = {
            data: [],  // Almacenará los datos de la API
            error: null, // Almacenará un mensaje de error en caso de que haya alguno
            searchTerm: '',  // Para el buscador
            orderBy: 'orderID',  // Por defecto, ordenaremos por orderID
            order: 'asc',
            isHistoryModalOpen: false,
            orderHistory: [],
        };
    }

    async componentDidMount() {
        try {
            const response = await fetch('api/Orders/all');

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

    handleOpenHistory = async (orderID) => {
        try {
            const response = await fetch(`api/order-status-history/all/${orderID}`);
            if (!response.ok) {
                throw new Error("Error al obtener datos de la API");
            }
            const data = await response.json();
            this.setState({
                isHistoryModalOpen: true,
                orderHistory: data.data
            });
        } catch (error) {
            console.error(error);
            this.setState({ error: "Ocurrió un error al obtener los datos." });
        }
    };

    handleCloseHistory = () => {
        this.setState({ isHistoryModalOpen: false });
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
            <DragDropContext>
                <Container >
                    <div style={{
                        display: 'flex',
                        justifyContent: 'space-between',
                        alignItems: 'center',
                        margin: 20,
                        padding: '0 10px'  // Añade padding a la derecha e izquierda
                    }}>
                        <Typography variant="h2" style={{ fontWeight: 'bold', color: 'orange' }}>
                            Historial
                        </Typography>
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
                            style={{ marginBottom: 20 }}
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
                                    <TableCell style={{ ...styles.tableHeader, width: '100px' }}>HISTORIAL</TableCell>
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
                                        <TableCell style={{ width: '100px', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                            <IconButton color="primary" onClick={() => this.handleOpenHistory(order.orderID)}>
                                                <HistoryIcon />
                                            </IconButton>
                                        </TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </Paper>
                    <Dialog
                        open={this.state.isHistoryModalOpen}
                        onClose={this.handleCloseHistory}
                        fullWidth
                        maxWidth="md"
                    >
                        <DialogTitle>Historial de Pedido</DialogTitle>
                        <DialogContent>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Fecha</TableCell>
                                        <TableCell>Comentario</TableCell>
                                        <TableCell>Estado</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {this.state.orderHistory.map((history, index) => (
                                        <TableRow key={index}>
                                            <TableCell>{history.date}</TableCell>
                                            <TableCell>{history.comment}</TableCell>
                                            <TableCell>{history.orderStatus.name}</TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={this.handleCloseHistory} color="primary">
                                Cerrar
                            </Button>
                        </DialogActions>
                    </Dialog>
                </Container>
                <Box sx={{
                    height: '800px',
                    overflow: 'auto',
                    width: '300px',
                }}>
                    <EventBarView />
                </Box>
            </DragDropContext>
        );
    }
}
