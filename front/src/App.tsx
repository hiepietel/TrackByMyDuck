import React from 'react';
import MainTab11 from './components/MainTab/components/MainTab';
import Login from './components/Auth/Login';
import { BrowserRouter as Router, Routes, Route, Link, BrowserRouter } from "react-router-dom";
import Layout from './components/Common/components/nav/Layout';
import { createMuiTheme, ThemeProvider } from '@mui/material';
import { purple } from '@mui/material/colors';
import UploadTrack from './components/UploadTrack/components/UploadTrack';
import Feed from './components/Feed/Feed';

const CLIENT_ID= "6de1c633b2044d088199775ad798e1e6"
const SPOTIFY_AUTHORIZE_ENDPOINT = "https://accounts.spotify.com/authorize"
const REDIRECT_URL_AFTER_LOGIN ="http://localhost:3000"
const SPACE_DELIMETER = "%20"
const SCOPES = ["user-read-currently-playing", "user-read-playback-state", "playlist-modify-public"];
const SCOPES_URL_PARAM = SCOPES.join(SPACE_DELIMETER)

const theme = createMuiTheme({
  palette: {
    primary: {
      main: '#fefefe'
    },
    secondary: purple
  },
  typography: {
    fontFamily: 'Quicksand',
    fontWeightLight: 400,
    fontWeightRegular: 500,
    fontWeightMedium: 600,
    fontWeightBold: 700,
  }
})

const App :React.FC= () => {
  return (
    // <Layout>
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route  path="/" element={<Login /> }/>
            <Route path="create" element={<UploadTrack />} /> 
            <Route path="main" element={<Feed />} />
          </Routes>
        </Layout>
      </BrowserRouter>
    </ThemeProvider>
    );
    {/* </Layout> */}

  
}

// const Layout :React.FC = (data) => {
//   return (
//     <>
//       {/* A "layout route" is a good place to put markup you want to
//           share across all the pages on your site, like navigation. */}
//       <nav>
//         <ul>
//           <li>
//             <Link to="/">Login</Link>
//           </li>
//           <li>
//             <Link to="/main">Main</Link>
//           </li>
//           <li>
//             <Link to="/add">Login</Link>
//           </li>
//         </ul>
//       </nav>

//     </>
//   );
// }

export default App;