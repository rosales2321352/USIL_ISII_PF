import React, { useEffect } from 'react';
import ClientContext from '../../../../../../context/Client/client.context';
import { CompanyForm } from '../../../../../common/interface';
import {Box,Typography} from '@mui/material';
import useApi, { submitApi } from '../../../../../../hooks/useApi';

export default function CompanyInformationView(){
  const [companyForm,setCompanyForm] = React.useState(CompanyForm);
  const [companyFormPrevious,setCompanyFormPrevious] = React.useState(CompanyForm);
  const [company,setCompany] = React.useState(null);
  const [reload,setReload] = React.useState(false);
  const ClientContext_ = React.useContext(ClientContext);
  

  useEffect(() => {
    setCompanyForm(CompanyForm);
    setCompanyFormPrevious(CompanyForm);
  },[ClientContext_.current_client])

  useEffect(() => {
    if(ClientContext_.current_client.company?.companyID){
      submitApi({
        url: process.env.REACT_APP_URL_COMPANY_DETAIL +'/'+ ClientContext_.current_client.company.companyID,
        options:{
          method: "GET",
        }
      }).then((data) => {
        if(data && data.statusCode === 200){
          setCompany(data.data);
        }
      })
    }      
  },[ClientContext_.current_client,reload])

  React.useEffect(() => {
    if(company){
      setCompanyForm({
          companyID: company.companyID?company.companyID:null,
          name: company.name?company.name:"",
          ruc: company.ruc?company.ruc:"",
          address: company.address?company.address:"",
          email: company.email?company.email:"",
      })
      setCompanyFormPrevious(companyForm);
    }
  },[company])

  const handlerChange = (e) => {
    setCompanyFormPrevious(companyForm);
    setCompanyForm({
      ...companyForm,
      [e.target.name]: e.target.value
    })
  }

  const handlerSubmit = (e) => {
    if(companyForm.companyID!==null){
      if(companyForm[e.target.name] !== companyFormPrevious[e.target.name]){
        submitApi({
          url: process.env.REACT_APP_URL_COMPANY_UPDATE,
          options:{
            method: "PUT",
            body: JSON.stringify(companyForm)
          }
        }).then(() => {
          setReload(!reload);
        })
      }
    }else{
      
    }
    
  }

  return (
    <>
      <Box sx={{mt:2,borderBottom:"1px solid #000",pb:1}}>
        <Typography sx={{fontSize:"14px"}}>Empresa</Typography>
      </Box>
      <Box sx={{mt:2}}>
        <Box className="container-input-client-information">
          <Typography sx={{fontSize:"14px"}} component={'span'}>Nombre:</Typography>
          <input type='text' name='name' onBlur={handlerSubmit} onChange={handlerChange} value={companyForm.name}/>
        </Box>
        <Box className="container-input-client-information">
          <Typography sx={{fontSize:"14px"}} component={'span'}>RUC:</Typography>
          <input type='text' name='ruc' onBlur={handlerSubmit} onChange={handlerChange} value={companyForm.ruc}/>
        </Box >
        <Box className="container-input-client-information">
          <Typography sx={{fontSize:"14px"}} component={'span'}>Dirección:</Typography>
          <input type='text' name='address' onBlur={handlerSubmit} onChange={handlerChange} value={companyForm.address}/>
        </Box>
        <Box className="container-input-client-information">
          <Typography sx={{fontSize:"14px"}} component={'span'}>Correo:</Typography>
          <input type='text' name='email' onBlur={handlerSubmit} onChange={handlerChange} value={companyForm.email}/>
        </Box>
      </Box>
    </>
  )
}