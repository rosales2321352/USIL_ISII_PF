import * as React from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import UserData from '../UserData';

export default function Tableview(data) 
{
    return <>
    <div>
        <div className='text-end'><Link to="/Guardar" className='btn btn-primary'>Add +</Link></div>
        
       <MaterialTable options={{sorting:true, search:true, searchText: "9999",
        searchFieldAlignment: "left", searchAutoFocus: true, searchFieldVariant: "standard"}} title= "Contactos" />

        <table className='table'>
                <thead className='thead'>
                    <tr className='tr'>
                            <th className='th'>ID</th>
                            <th className='th'>Nombre</th>
                            <th className='th'>Numero</th>
                            <th className='th'>Estado</th>
                            <th className='th'>Direccion</th>
                            <th className='th'>Pais</th>
                            <th className='th'>RUC</th>
                            <th className='th'>Actions</th>
                    </tr>
                </thead>
                <tbody>
                        <UserData client={data}/>
                </tbody>
        </table>
    </div>
        
    
    </>
}
