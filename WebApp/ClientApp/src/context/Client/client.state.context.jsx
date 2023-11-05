import * as React from "react";
import ClientContext from "./client.context";
import ClientReducer from "./client.reducer.context";
import { initialContext } from "./object";

export default function ClientState({children}){

  const [state,dispatch] = React.useReducer(ClientReducer,initialContext);

  const setClientState = (type,payload) => {
    dispatch({type:type,payload: {...state,...payload}});
  }

  const setCurrentClient = (current_client) => {
    setClientState("SET_CURRENT_CLIENT",{ current_client });
  }

  const clientContext = {
    ...state,
    setCurrentClient,
  }

  return (
    <ClientContext.Provider value={clientContext}>
      {children}
    </ClientContext.Provider>
  )

}