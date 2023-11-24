import * as React from 'react';
import { Link } from 'react-router-dom';
import UserData from '../UserData';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';


export default function Tableview({data}) 
{
    return (
        <>
            <div>
                <div className='text-end'>
                    <Link to="/Guardar" className='btn btn-primary'>Add +</Link>
                </div>

                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>ID</TableCell>
                                <TableCell>Nombre</TableCell>
                                <TableCell>Numero</TableCell>
                                <TableCell>Estado</TableCell>
                                <TableCell>Direccion</TableCell>
                                <TableCell>Pais</TableCell>
                                <TableCell>RUC</TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <UserData client={data} />
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
        </>
    );
}
