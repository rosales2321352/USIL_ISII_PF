import * as React from 'react';
import useApi from '../../../../../../../hooks/useApi';

export default function TypeAnnotationView({typeAnnotationId,form}) {

  const {noteForm, setNoteForm} = form;

  const annotationType = useApi({
    url: process.env.REACT_APP_URL_ANNOTATION_TYPE_LIST,
    options:{
      method: "GET",
    },
    condition:[typeAnnotationId]
  })

  const handleChange = (event) => {
    //console.log(event.target.selectedOptions[0].value);
    setNoteForm({
      ...noteForm,
      annotationTypeID: parseInt(event.target.selectedOptions[0].value)
    })
  };

  return(
    <select className='form-control' style={{width:"250px",display:"inline-block",marginLeft: "20px",padding: "5px"}} value={noteForm.annotationTypeID} onChange={handleChange}>
      <option value="">Tipo de Nota</option>
      {annotationType.data && Array.isArray(annotationType.data) && annotationType.data.map((type,index)=>(
        <option key={index}  value={type.annotationTypeID}>{type.name}</option>
      ))}
    </select>

  )

}