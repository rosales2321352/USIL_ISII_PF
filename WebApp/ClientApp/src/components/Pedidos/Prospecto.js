import React, { Component } from 'react';
import { Table, TableBody, TableCell, TableHead, TableRow, Paper, Select, MenuItem, IconButton, Typography } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
export class Prospecto extends Component {
    static displayName = Prospecto.name;

    // Datos de ejemplo para la tabla
    rows = [
        { cliente: 'Arnold Pajuelo Araujo', estado: 'Prospecto', telefono: '904089518', direccion: '-', correo: 'arnold@usil.pe' },
        // Puedes agregar más registros aquí
    ];

    handleChange = (index, event) => {
        const newRows = [...this.rows];
        newRows[index].estado = event.target.value;
        this.setState({ rows: newRows });
    }

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

        return (
            <div>
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

                <Paper elevation={3} style={{ margin: 20 }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell style={styles.tableHeader}>CLIENTE</TableCell>
                                <TableCell style={styles.tableHeader}>ESTADO</TableCell>
                                <TableCell style={styles.tableHeader}>TELÉFONO</TableCell>
                                <TableCell style={styles.tableHeader}>DIRECCIÓN</TableCell>
                                <TableCell style={styles.tableHeader}>CORREO</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {this.rows.map((row, index) => (
                                <TableRow key={index}>
                                    <TableCell style={styles.tableCell}>{row.cliente}</TableCell>
                                    <TableCell style={styles.tableCell}>
                                        <Select
                                            style={styles.select}
                                            value={row.estado}
                                            onChange={(event) => this.handleChange(index, event)}
                                        >
                                            <MenuItem value="Prospecto">Prospecto</MenuItem>
                                            <MenuItem value="Orden de Compra">Orden de Compra</MenuItem>
                                            <MenuItem value="Finalizado">Finalizado</MenuItem>
                                            <MenuItem value="Cancelado">Cancelado</MenuItem>
                                        </Select>
                                    </TableCell>
                                    <TableCell style={styles.tableCell}>{row.telefono}</TableCell>
                                    <TableCell style={styles.tableCell}>{row.direccion}</TableCell>
                                    <TableCell style={styles.tableCell}>{row.correo}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
            </div>
        );
    }
}
