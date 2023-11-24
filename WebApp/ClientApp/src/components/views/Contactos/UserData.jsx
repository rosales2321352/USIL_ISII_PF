import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link, useNavigate } from 'react-router-dom';

const UserData = ({ client }) => {
    const navigate = useNavigate();

    function handleSubmit(id) {
        const conf = window.confirm("¿Está seguro de eliminar este cliente?");
        if (conf) {
            fetch(`https://localhost:44445/api/client/${id}`, {
                method: 'DELETE',
            })
                .then(response => {
                    if (response.ok) {
                        return response.json();
                    }
                    throw new Error('Network response was not ok.');
                })
                .then(() => {
                    alert('Cliente fue eliminado.');
                    navigate("/client");
                })
                .catch(err => console.log(err))
        }
    }

    return (
        <>
            {
                client.map((curClient) => {
                    const { id, name, phoneNumber, clientStatus, companyAddress } = curClient;

                    return (
                        <tr key={id}>
                            <td>{id}</td>
                            <td>{name}</td>
                            <td>{phoneNumber}</td>
                            <td>{clientStatus}</td>
                            <td>{companyAddress}</td>
                            <td>
                                <Link to={`/update/${curClient.id}`}><EditIcon /></Link>
                                <button onClick={e => handleSubmit(curClient.id)} className='btn btn-sm ms-1'><DeleteIcon /></button>
                            </td>
                        </tr>
                    )
                })
            }
        </>
    )
}

export default UserData;