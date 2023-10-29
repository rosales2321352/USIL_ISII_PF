import React from 'react';
import styled from 'styled-components';
import CloseIcon from '@mui/icons-material/Close';

const Modal = ({children, estado, cambiarEstado }) => {
    return (
        <>
            {estado && 
            <Overlay>
                <ContenedorModal>
                    <EncabezadoModal>
                        <h3>
                        Titulo</h3>
                        </EncabezadoModal>
                        <BotonCerrar onClick={() => cambiarEstado(false)}> <CloseIcon /> </BotonCerrar>
                    {children}
                   <h1>creacion de contactos</h1> 
                </ContenedorModal>
            </Overlay>
            }
        </>
    )
}

export default Modal;

const Overlay = styled.div`
    width: 100w;
    hight: 100vh;
    position: fixed;
    top: 0;
    left: 0;
    background: rgba(0,0,0,.5);
    padding: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
`;

const ContenedorModal = styled.div`
    width: 500px;
    min-hight: 100px;
    background: #fff;
    position: relative;
    border-radius: 5px;
    box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
    padding: 20px;
`;

const EncabezadoModal = styled.div`
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-botton: 20px;
    padding-botton: 20px;
    border-botton: 1px solid #E8E8E8;
    
    h3{
        font-weight: 500;
        font-size: 16px;
        color:  #1766DC;
    }
`;

const BotonCerrar = styled.button`
    position: absolute;
    top: 15px;
    right: 20px;
    widht: 30px;
    height: 30px;
    border: none;
    background:none;
    cursor: pointer;
    transition: .3 ease all;
    border-radius: 5px;
    color: #1766DC;

    &:hover{
        background: #f2f2f2;
    }

`;
