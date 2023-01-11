import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';

const SPACE_DELIMETER = "%20"
const SCOPES = ["user-read-currently-playing", "user-read-playback-state", "playlist-modify-public"];
const SCOPES_URL_PARAM = SCOPES.join(SPACE_DELIMETER)

const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});


const getReurnedParamsFromSpotifyAuth = (hash:any) => {
  console.log(hash)
  const stringAfterHashtah = hash.substring(1);
  const paramsInUrl = stringAfterHashtah.split("&");
  const paramsPLitUp = paramsInUrl.reduce((accumulater:any, currentValue:any) => {
    const [key, value] = currentValue.split("=");
    accumulater[key] = value;
    return accumulater;
  }, {});

  return paramsPLitUp;
}

const logiToApi = (token:any) =>{
  axios.post(process.env.REACT_APP_API_URL + "/Auth", token)
    .then(res => {
      console.log(res.data)
      sessionStorage.setItem("token", `bearer ${res.data}`);
      instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(`bearer ${res.data}`  ));
    })

}
const Login :React.FC = () => {

    const navigate = useNavigate();
    const [token, setToken] = useState("");
    //const location = useLocation();
    useEffect(() => {
        console.log(window.location.hash)
      if(window.location.hash){
        console.log(window.location.href);
        var token = getReurnedParamsFromSpotifyAuth(window.location.hash);
        logiToApi(token)
        navigate("/main")
      }
    });
    const handleLogin = () =>{
      
      window.location.href = `${process.env.REACT_APP_SPOTIFY_AUTHORIZE_ENDPOINT}?client_id=${process.env.REACT_APP_CLIENT_ID}&redirect_uri=${process.env.REACT_APP_REDIRECT_URL_AFTER_LOGIN}&scope=${SCOPES_URL_PARAM}&response_type=token&show_dialog=true`
    }
    return (
      <div style={{height: "100vh", width: "100%", backgroundColor: "#8C92AC", top: 0, left: 0, position: "fixed"}}>
        <div style={{textAlign: "center"}}>
          <h1>Log in to track by my duck</h1>
          <Button variant="contained"
              onClick={handleLogin}>
                Login
          </Button>
        </div>

      </div>

    );
}

export default Login