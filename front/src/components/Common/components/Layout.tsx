import { AppBar, BottomNavigation, BottomNavigationAction, Box, Button, Paper, Toolbar } from '@mui/material';
import React from 'react'
import { useNavigate } from 'react-router-dom';

const Layout = () => {

  const navigate = useNavigate();

  return (
    <Box sx={{ flexGrow: 1 }}>
    <AppBar position="static">
    <Toolbar>
    <Button color="inherit" onClick={()=> navigate("/main")}>Playlist</Button>
    <Button color="inherit" onClick={()=> navigate("/add")}>Add</Button>
    </Toolbar>
      </AppBar>
      </Box>


  )
}

export default Layout