export default function EventReducer(state,action){

  switch(action.type){
    case "SET_CURRENT_RELOAD":
      return {
        ...state,
        reload: action.payload.reload
      }
    default:
      return state;
  }

}