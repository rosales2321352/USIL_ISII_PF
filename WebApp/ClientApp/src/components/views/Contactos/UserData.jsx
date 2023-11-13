import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

const UserData = ({client}) => 
{
    const navigate = useNavigate();

    return(
        <>
            {
                client.map((curClient) =>
                {
                    const {id, name, phoneNumber, clientStatus, companyAddress} = curClient;

                    return(
                        <tr key={id}>
                            <td>{id}</td>
                            <td>{name}</td>
                            <td>{phoneNumber}</td>
                            <td>{clientStatus}</td>
                            <td>{companyAddress}</td>
                            <td>
                                <Link to={`/update/${curClient.id}`}><EditIcon/></Link>
                                <button onClick={e=> handleSubmit(curClient.id)} className='btn btn-sm ms-1'><DeleteIcon/></button> 
                            </td>
                        </tr>
                    )
                })
            }
        </>
    )
    function handleSubmit(id){
        const conf = window.confirm("¿Esta seguro de eliminar este cliente?");
        if(conf){
            axios.delete('https://localhost:44445/api/client/' + id)
            .then(res=> {
                alert('cliente fue eliminado.');
                navigate("client");
            }).catch(err => console.log(err))
        }
    }
}

export default UserData;