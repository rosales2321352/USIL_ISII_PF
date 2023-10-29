import React, { useState } from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import Button from '@mui/material/Button';
import Preview from '@mui/icons-material/Preview';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem'; import Delete from '@mui/icons-material/Delete'; import Edit from '@mui/icons-material/Edit';
import { Box, IconButton, Tooltip } from '@mui/material';
import Contactos from "../Contactos";

const columns = [
    { id: 'nombre', label: 'Nombre', minWidth: 170 },
    { id: 'pais', label: 'Pais', minWidth: 100 },
    {
        id: 'tipoCliente',
        label: 'Tipo de Cliente',
        minWidth: 170,
        align: 'right',
    },
    {
        id: 'telefono',
        label: 'Telefono',
        minWidth: 170,
        align: 'center',
    },
    {
        id: 'direccion',
        label: 'Direccion',
        minWidth: 170,
        align: 'center',
        format: (value) => value.toLocaleString('en-US'),
    },
    {
        id: 'transacciones',
        label: 'Transacciones',
        minWidth: 170,
        align: 'center',
    },
];

function createData(nombre, pais, transacciones, telefono, direccion) {
    return { nombre, pais, transacciones, telefono, direccion};
}
const rows = [
    createData('Laleska', 'India',  2, 3287263, 'Av. Maria Ax'),
    createData('Arturo', 'China', 1, 9596961, 'Av. Maria Ax'),
    createData('Mauricio', 'Italy', 0, 301340, 'Av. Maria Ax'),
    createData('Crazy', 'United States', 3, 9833520, 'Av. Maria Ax'),
    createData('Chato', 'Canada', 4, 9984670, 'Av. Maria Ax'),
    createData('Mia', 'Australia', 4, 7692024, 'Av. Maria Ax'),
    createData('Chiki', 'Germany', 2, 357578, 'Av. Maria Ax'),
    createData('Marco', 'Ireland', 5, 70273, 'Av. Maria Ax'),
    createData('Antonio', 'Mexico', 2, 1972550, 'Av. Maria Ax'),
    createData('Aldhair', 'Japan', 1, 377973, 'Av. Maria Ax'),
    createData('Adrian', 'France', 1, 640679, 'Av. Maria Ax'),
    createData('Jesus', 'United Kingdom', 1, 242495, 'Av. Maria Ax'),
    createData('Leonor', 'Russia', 1, 17098246, 'Av. Maria Ax'),
    createData('Elizabeth', 'Nigeria', 1, 923768, 'Av. Maria Ax'),
    createData('Johanna', 'Brazil', 1, 8515767, 'Av. Maria Ax'),
    createData('Fila Vacía', '', null, null, '', null),
];

export default function StickyHeadTable() {
    
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(10);
    const [selectedRow, setSelectedRow] = useState(null);
  
    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    const handleViewDetails = (row) => {
        setSelectedRow(row);
    };

    /*const handleEdit = (row) => {
    
    };

    const handleDelete = (row) => {
        
    };
    */

    return (
        <div>
            <Paper sx={{ width: '100%', overflow: 'hidden' }}>
                <TableContainer sx={{ maxHeight: 440 }}>
                    <Table stickyHeader aria-label="sticky table">
                        <TableHead>
                            <TableRow>
                                {columns.map((column) => (
                                    <TableCell
                                        key={column.id}
                                        align={column.align}
                                        style={{ minWidth: column.minWidth }}
                                    >
                                        {column.label}
                                    </TableCell>
                                ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row, index) => (
                                    <TableRow key={index}>
                                        {columns.map((column) => (
                                            <TableCell key={column.id} align={column.align}>
                                                {column.id === 'tipoCliente' ? (
                                                    <Select
                                                        value={row.tipoCliente}
                                                        onChange={(event) => {
                                                            const newValue = event.target.value;
                                                            const updatedRows = [...rows];
                                                            updatedRows[index].tipoCliente = newValue;
                                                            rows[index] = updatedRows[index];
                                                        }}
                                                    >
                                                        <MenuItem value="clientePromedio">Cliente Promedio</MenuItem>
                                                        <MenuItem value="clienteNuevo">Cliente Nuevo</MenuItem>
                                                        <MenuItem value="clienteDestacado">Cliente Destacado</MenuItem>
                                                    </Select>
                                                ) : column.format && typeof row[column.id] === 'number' ? (
                                                    column.format(row[column.id])
                                                ) : (
                                                    row[column.id]
                                                )}
                                            </TableCell>
                                        ))}
                                    <TableCell key="actions" align="center">
                                        <Box>
                                            <Tooltip title="Ver contacto">
                                                <IconButton
                                                   // onClick={() => dispatch({ type: 'UPDATE_ROOM', payload: params.row })}
                                                    //onClick={() => handleViewDetails(row)}
                                                       
                                                >
                                                    <Preview />
                                                    
                                                </IconButton>
                                            </Tooltip>
                                            <Tooltip title="Editar contacto">
                                                <IconButton onClick={() => { }}>
                                                    <Edit />
                                                </IconButton>
                                            </Tooltip>
                                            <Tooltip title="Eliminar contacto">
                                                <IconButton
                                                 //   onClick={() => deleteRoom(params.row, currentUser, dispatch)}
                                                >
                                                    <Delete />
                                                </IconButton>
                                            </Tooltip>
                                        </Box>
                                    </TableCell>
                                    </TableRow>
                                ))}
                        </TableBody>
                    </Table>
                </TableContainer>
                <TablePagination
                    rowsPerPageOptions={[10, 25, 100]}
                    component="div"
                    count={rows.length}
                    rowsPerPage={rowsPerPage}
                    page={page}
                    onPageChange={handleChangePage}
                    onRowsPerPageChange={handleChangeRowsPerPage}
                />
            </Paper>
            {selectedRow && (
                <Contactos row={selectedRow} />
            )}
        </div >
        
    );
}