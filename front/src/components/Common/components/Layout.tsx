import { BottomNavigation, BottomNavigationAction, Paper } from '@mui/material';
import React from 'react'

const Layout = () => {
  return (
    <Paper sx={{ }} elevation={3}>
        <BottomNavigation
          showLabels
        >
          <BottomNavigationAction label="Recents"  />
          <BottomNavigationAction label="Favorites"  />
          <BottomNavigationAction label="Archive" />
        </BottomNavigation>
      </Paper>
  )
}

export default Layout