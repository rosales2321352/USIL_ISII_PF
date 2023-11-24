import * as React from "react";
import NoteContext from "./note.context";
import NoteReducer from "./note.reducer.context";
import { initialContext } from "./object";

export default function NoteState({children}){

  const [state,dispatch] = React.useReducer(NoteReducer,initialContext);

  const setNoteState = (type,payload) => {
    dispatch({type:type,payload: {...state,...payload}});
  }

  const setReload = (reload) => {
    setNoteState("SET_CURRENT_RELOAD",{ reload });
  }

  const noteContext = {
    ...state,
    setReload,
  }

  return (
    <NoteContext.Provider value={noteContext}>
      {children}
    </NoteContext.Provider>
  )

}