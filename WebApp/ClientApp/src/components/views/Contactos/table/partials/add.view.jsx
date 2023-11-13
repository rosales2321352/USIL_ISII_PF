import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function Add() {
    const [inputData, setInputData] = useState({name:'', number:''})
    const navigat = useNavigate();
    
    function handleSubmit(event){
        event.preventDefault()

        axios.post('https://localhost:44445/api/client', inputData)
        .then(res=> {
            alert("Cliente Agregado Satisfactoriamente.");
            navigat('client');
        }).catch(err => console.log(err));
    }
    
  return (
    <div className='d-flex w-100 h-100'>
        <div className='w-50 border bg-ligth p-5'>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="name">Name</label>
                    <input type='text' name='name' className='form-control' 
                    onChange={e => setInputData({...inputData, name: e.target.value})} />
                    
                </div>
                <div>
                    <label htmlFor="number">Number</label>
                    <input type='number' name='number' className='form-control'
                    onChange={e => setInputData({...inputData, number: e.target.value})} />
                </div><br/>

                <button className='btn btn-info' >Submit</button>
            </form>
        </div>
    </div>
  )
}
