//create reducer 

export default function ContactosReducer(state,action){

    switch(action.type){
      case "SET_RELOAD":
        return {
          ...state,
          reload: action.payload.reload
        }
      default:
        return state;
    }
  
  }