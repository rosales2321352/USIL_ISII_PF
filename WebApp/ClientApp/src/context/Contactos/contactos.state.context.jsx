import * as React from "react";
import { initialContext } from "./object";
import ContactosContext from "./contactos.context";
import ContactosReducer from "./contactos.reducer.context";

export default function ContactostState({children}){

  const [state,dispatch] = React.useReducer(ContactosReducer,initialContext);

  const setContactosState = (type,payload) => {
    dispatch({type:type,payload: {...state,...payload}});
  }

  const setReload = (reload) => {
    setContactosState("SET_RELOAD",{ reload });
  }

  const contactosContext = {
    ...state,
    setReload,
  }

  return (
    <ContactosContext.Provider value={contactosContext}>
      {children}
    </ContactosContext.Provider>
  )

}