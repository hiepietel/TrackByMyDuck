import {
  Container,
} from "@material-ui/core";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import FacebookLogin from "react-facebook-login";

const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});

const FacebookLogIn = () => {
  const navigate = useNavigate();

  const responseFacebook = (response: any) => {
    console.log(response);
    // var res = {
    //   accessToken: response.accessToken
    // }
    axios
      .post(process.env.REACT_APP_API_URL + "/api/Auth/facebook-login", {
        AccessToken: response.accessToken,
        provider: response.graphDomain,
        email: response.email,
        name: response.name,
        facebookId: response.Id,
        imgHref: response.picture.data.url,
      })
      .then((res) => {
        console.log(res.data);
        sessionStorage.setItem("token", `bearer ${res.data.accessToken}`);
        instance.defaults.headers.common["Authorization"] = unescape(
          encodeURIComponent(`bearer ${res.data}`)
        );
        navigate("/main");
      });
  };

  return (
    <Container maxWidth="xs">
      <FacebookLogin
        isDisabled={false}
        appId={process.env.REACT_APP_FACEBOOK_APP_ID ?? ""}
        autoLoad={true}
        fields="name,email,picture"
        callback={responseFacebook}
      />
    </Container>
  );
};

export default FacebookLogIn;