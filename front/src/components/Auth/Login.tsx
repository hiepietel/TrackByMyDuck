import React from "react";
import SignIn from "./SignIn";
import SignUp from "./SignUp";
import FacebookLogIn from "./FacebookLogIn";
import { Box, Container, Tab, Tabs, Typography } from "@material-ui/core";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function CustomTabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}

const Login: React.FC = () => {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" component="h4">
        Track by my duck :DDD
      </Typography>

      <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
        <Tabs
          value={value}
          onChange={(ev: any, newValue: any) => {
            handleChange(ev, newValue);
          }}
          aria-label="basic tabs example"
        >
          <Tab label="Sign In" {...a11yProps(0)} />
          <Tab label="Sign Up" {...a11yProps(1)} />
          <Tab label="Fogin with Facebook" {...a11yProps(2)} />
        </Tabs>
      </Box>
      <CustomTabPanel value={value} index={0}>
        <SignIn />
      </CustomTabPanel>
      <CustomTabPanel value={value} index={1}>
        <SignUp />
      </CustomTabPanel>
      <CustomTabPanel value={value} index={2}>
        <FacebookLogIn />
      </CustomTabPanel>

      {/* <FacebookLogIn />
      <SignIn />
      <SignUp /> */}
    </Container>
  );
};

export default Login;

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
