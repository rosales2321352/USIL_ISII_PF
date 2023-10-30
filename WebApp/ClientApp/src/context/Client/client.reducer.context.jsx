//create reducer 

export default function ClientReducer(state,action){

  switch(action.type){
    case "SET_CURRENT_CLIENT":
      return {
        ...state,
        current_client: action.payload.current_client
      }
    default:
      return state;
  }

}