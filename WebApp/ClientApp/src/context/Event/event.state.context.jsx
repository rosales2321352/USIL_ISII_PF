import * as React from "react";
import EventContext from "./event.context";
import EventReducer from "./event.reducer.context";
import { initialContext } from "./object";

export default function EventState({children}){

  const [state,dispatch] = React.useReducer(EventReducer,initialContext);

  const setEventState = (type,payload) => {
    dispatch({type:type,payload: {...state,...payload}});
  }

  const setReload = (reload) => {
    setEventState("SET_CURRENT_RELOAD",{ reload });
  }

  const eventContext = {
    ...state,
    setReload,
  }

  return (
    <EventContext.Provider value={eventContext}>
      {children}
    </EventContext.Provider>
  )

}