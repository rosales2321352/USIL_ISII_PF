import { useState,useEffect } from "react";
//import AESUtil from "../common/AESUtil";
//import SessionContext from "@context/Session/SessionContext";


/*interface IApiData {
  url : string;
  options : RequestInit;
  condition? : Array<any>;
  getToken? : boolean
}*/
 //const useApi type T extends 

function useApi(apiData) {
  //const {isAuthenticated,setIsAuthenticated} = useContext(SessionContext);
  const [total_rows, setTotalRows] = useState(0);
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);
  /*let token = localStorage.getItem("token");
  if (token && !apiData.getToken) {
    apiData.url = apiData.url + token;
  }*/
  const abortController = new AbortController();
  const signal = abortController.signal;
  apiData.options.signal = signal;

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      /* if(apiData.options.body){
        const encryptedData = await AESUtil.encryptData(apiData.options.body);
        apiData.options.body = encryptedData;
      }*/

      fetch(apiData.url, apiData.options)
      .then((res) => res.ok ? res.json() : Promise.reject({
        status: res.status,
        statusText: res.statusText
      }))
      .then((data_) => {

        if(data_){
          setData(data_);
          setError(null);
        }

        //if(data["status_code"] === 200){
          //setData(data["data"]);
          //if(data["total_rows"]) setTotalRows(data["total_rows"]);
          //setError(null);
        //}
      
        //setError(data["message"]);

        /*AESUtil.decrypt(data).then((decryptedData:any) => {
          const decryptedText = new TextDecoder().decode(decryptedData);
          let data_json = JSON.parse(decryptedText);
          if(data_json["statusCode"] === 200){
            setData(data_json["data"]);
            if(data_json["totalRecords"]) setTotalItems(data_json["totalRecords"]);
            setError(null);
          }else
            if(data_json["statusCode"] === 401){
              //if(isAuthenticated) setIsAuthenticated(false);
          }
          setError(data_json["message"]);
        
        }).catch((error:any) => {
          setError(error);
        });*/
      })
      .catch((err) => {
        console.log(err);
        setError(err)
      })
      .finally(() => setLoading(false));
    };
    fetchData();
  }, apiData.condition);
  return { data, error, loading ,total_rows ,setData};
}

export async function  submitApi  (apiData) {
  //const {isAuthenticated,setIsAuthenticated} = useContext(SessionContext);
  //apiData.options.headers = { "Content-Type": "application/json" };
  /*let token = localStorage.getItem('token');
  if (token && !apiData.getToken) {
    apiData.url = apiData.url + token;
  }*/
  /*if(apiData.options.body){
    const encryptedData = await AESUtil.encryptData(apiData.options.body);
    apiData.options.body = encryptedData;
  }*/

  const abortController = new AbortController();
  const signal = abortController.signal;
  apiData.options.signal = signal;
  return fetch(apiData.url, apiData.options)
    .then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        return Promise.reject({
          status: res.status,
          statusText: res.statusText,
        });
      }
    })
    /*.then((data) => {
      return AESUtil.decrypt(data).then((decryptedData: any) => {
        const decryptedText = new TextDecoder().decode(decryptedData);
        let data_json = JSON.parse(decryptedText);
        if(data_json["statusCode"] === 401){
        }
        return data_json;
      });
    })*/
    
}


export default useApi;