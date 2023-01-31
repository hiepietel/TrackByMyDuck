import axios from 'axios'
import React from 'react'
import { useNavigate } from 'react-router-dom';


const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});


// const getReurnedParamsFromSpotifyAuth = (hash:any) => {
//   console.log(hash)
//   const stringAfterHashtah = hash.substring(1);
//   const paramsInUrl = stringAfterHashtah.split("&");
//   const paramsPLitUp = paramsInUrl.reduce((accumulater:any, currentValue:any) => {
//     const [key, value] = currentValue.split("=");
//     accumulater[key] = value;
//     return accumulater;
//   }, {});

//   return paramsPLitUp;
// }

// const logiToApi = (token:any) =>{
//   axios.post(process.env.REACT_APP_API_URL + "/Auth", token)
//     .then(res => {
//       console.log(res.data)
//       //sessionStorage.setItem("token", `bearer ${res.data}`);
//       sessionStorage.setItem("token", `${res.data}`);
//       //instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(`bearer ${res.data}`  ));
//     })

// }
const Login :React.FC = () => {

    const navigate = useNavigate();
    //const location = useLocation();
    // useEffect(() => {
    //     console.log(window.location.hash)
    //   if(window.location.hash){
    //     console.log(window.location.href);
    //     var token = getReurnedParamsFromSpotifyAuth(window.location.hash);
    //     logiToApi(token)
    //     navigate("/main")
    //   }
    // });
    // const handleLogin = () =>{
      
    //   window.location.href = `${process.env.REACT_APP_SPOTIFY_AUTHORIZE_ENDPOINT}?client_id=${process.env.REACT_APP_CLIENT_ID}&redirect_uri=${process.env.REACT_APP_REDIRECT_URL_AFTER_LOGIN}&scope=${SCOPES_URL_PARAM}&response_type=token&show_dialog=true`
    // }

    const responseFacebook = (response:any) => {
      console.log(response)
      // var res = {
      //   accessToken: response.accessToken
      // }
      axios.post(process.env.REACT_APP_API_URL + "/Auth/facebook-login", {
        AccessToken: response.accessToken, 
        provider: response.graphDomain,
        email: response.email,
        name: response.name,
        facebookId: response.facebookId
        })
      .then(res => {
        console.log(res.data)
        sessionStorage.setItem("token", `bearer ${res.data.accessToken}`);
        instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(`bearer ${res.data}` ));
        navigate("/main") 
      })
    }

//style={{height: "100vh", width: "100%", backgroundColor: "#8C92AC", top: 0, left: 0, position: "fixed"}}
    return (
      <div>
          {/* <FacebookLogin
          isDisabled={true}
    appId={process.env.REACT_APP_FACEBOOK_APP_ID ?? ""}
    autoLoad={true}
    fields="name,email,picture"
    callback={responseFacebook} />, */}
        {/* <div style={{textAlign: "center"}}>
          <h1>Log in to track by my duck</h1>
          <Button variant="contained"
              onClick={handleLogin}>
                Login
          </Button>
        </div> */}
<button onClick={()=> responseFacebook({       
     accessToken: "accessToken", 
     graphDomain: "response.graphDomain",
        email: "testUser@email.pl",
        name: "Test user",
        facebookId: 123
        })}>Log in</button>
      </div>

    );
}

export default Login