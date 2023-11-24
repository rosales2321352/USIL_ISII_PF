import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

export default function Edit() {
    const {id} = useParams();
    const [data, setData] = useState([])
    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:44445/api/client/' + id)
            .then(response => response.json())
            .then(data => setData(data))
            .catch(err => console.log(err));
    }, [id]);

    function handleSubmit(event) {
        event.preventDefault();

        fetch('https://localhost:44445/api/client/' + id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(() => {
                alert("Cliente actualizado satisfactoriamente.");
                navigate('client');
            })
            .catch(err => console.log(err));
    }

    return (
        <div className='d-flex w-100 h-100'>
            <div className='w-50 border bg-ligth p-5'>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label htmlFor="name">ID</label>
                        <input type='text' name='name' value={data.id || ''} className='form-control' readOnly />
                    </div>
                    <div>
                        <label htmlFor="name">Name</label>
                        <input type='text' name='name' value={data.name || ''} className='form-control'
                            onChange={e => setData({ ...data, name: e.target.value })} />
                    </div>
                    <div>
                        <label htmlFor="number">Number</label>
                        <input type='number' name='number' value={data.number || ''} className='form-control'
                            onChange={e => setData({ ...data, number: e.target.value })} />
                    </div><br />

                    <button className='btn btn-info'>Update</button>
                </form>
            </div>
        </div>
    )
}
