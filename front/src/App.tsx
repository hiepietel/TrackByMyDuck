import React from 'react';
import Login from './components/Auth/Login';
import { Routes, Route, BrowserRouter } from "react-router-dom";
import Layout from './components/Common/components/nav/Layout';
import { createMuiTheme, ThemeProvider } from '@mui/material';
import { purple } from '@mui/material/colors';
import UploadTrack from './components/UploadTrack/components/UploadTrack';
import Feed from './components/Feed/Feed';


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
}


export default App;