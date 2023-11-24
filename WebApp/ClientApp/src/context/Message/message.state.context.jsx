import * as React from "react";
import MessageContext from "./message.context";
import MessageReducer from "./message.reducer.context";
import { initialContext } from "./object";

export default function MessageState({children}){

  const [state,dispatch] = React.useReducer(MessageReducer,initialContext);

  const setMessageState = (type,payload) => {
    dispatch({type:type,payload: {...state,...payload}});
  }

  const setReload = (reload) => {
    setMessageState("SET_CURRENT_RELOAD",{ reload });
  }

  const messageContext = {
    ...state,
    setReload,
  }

  return (
    <MessageContext.Provider value={messageContext}>
      {children}
    </MessageContext.Provider>
  )

}