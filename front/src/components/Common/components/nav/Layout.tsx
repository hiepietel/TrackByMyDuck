import React, { useEffect } from 'react'
import { styled, useTheme } from '@mui/material/styles';
import Drawer from '@material-ui/core/Drawer'
import Typography from '@material-ui/core/Typography'
import {useNavigate , useLocation } from 'react-router-dom'
import List from '@material-ui/core/List'
import ListItem from '@material-ui/core/ListItem'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import { AddCircleOutlineOutlined, SubjectOutlined } from '@material-ui/icons'
import Toolbar from '@material-ui/core/Toolbar'
import Avatar from '@material-ui/core/Avatar'
import IconButton from '@mui/material/IconButton';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import MuiAppBar from '@mui/material/AppBar';
import { makeStyles } from '@material-ui/core';
import MenuIcon from '@mui/icons-material/Menu';
import api from "../../../../config/configAxios"

const drawerWidth = 360

const useStyles = makeStyles((theme) => {
  return {
    page: {
      background: '#f9f9f9',
      width: '100%',
      padding: theme.spacing(3),
    },
    root: {
      display: 'flex',
    },
    drawer: {
      width: drawerWidth,
    },
    drawerPaper: {
      width: drawerWidth,
    },
    active: {
      background: '#f4f4f4'
    },
    title: {
      padding: theme.spacing(2),
      flexGrow: 1
    },
    appBar: {
      width: `calc(100% - ${drawerWidth}px)`,
      marginLeft: drawerWidth,
    },
    date: {
      flexGrow: 1
    },
    toolbar: theme.mixins.toolbar,
    avatar: {
      marginLeft: theme.spacing(2)
    }
  }
})

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  padding: theme.spacing(0, 1),
  // necessary for content to be below app bar
  ...theme.mixins.toolbar,
  justifyContent: 'flex-end',
}));

const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })<{
  open?: boolean;
}>(({ theme, open }) => ({
  flexGrow: 1,
  padding: theme.spacing(3),
  transition: theme.transitions.create('margin', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  marginLeft: `-${drawerWidth}px`,
  ...(open && {
    transition: theme.transitions.create('margin', {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
    marginLeft: 0,
  }),
}));

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open' })<{open?: boolean;}>(({ theme, open }) => ({
  transition: theme.transitions.create(['margin', 'width'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    width: `calc(100% - ${drawerWidth}px)`,
    marginLeft: `${drawerWidth}px`,
    transition: theme.transitions.create(['margin', 'width'], {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

interface LayoutProps{
    children: any
}

const Layout: React.FC<LayoutProps> =({ children }) =>{
  const classes = useStyles()
  const history = useNavigate ()
  const location = useLocation()
  const theme = useTheme();
  
  const [open, setOpen] = React.useState(false);
  const [userinfo, setUserInfo] = React.useState<any>({});

  useEffect(() => {
    api.get("/Auth/user-info")
        .then((res :any)=> {
          console.log(res.data)
          setUserInfo(res.data);
          //setTracks(res.data);
        })
        .catch((err:any) => {
          console.log(err);
        });
  }, [])
  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const menuItems = [
    { 
      text: 'Tracks', 
      icon: <SubjectOutlined color="secondary" />, 
      path: '/main' 
    },
    { 
      text: 'Add new Track', 
      icon: <AddCircleOutlineOutlined color="secondary" />, 
      path: '/create' 
    },
  ];

  return (
    <div className={classes.root}>
      {/* app bar */}
      <AppBar 
        position="fixed" 
        className={classes.appBar}
        elevation={0}
        color="primary"
        open={open}
      >
        <Toolbar>
        <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            style={{ ...(open && { display: 'none' }) }}
          >
             <MenuIcon />
          </IconButton>
          <Typography variant="h5" className={classes.title}>
            TrackByMyDuck
          </Typography>
          <Typography>{userinfo.name}</Typography>
          <Avatar className={classes.avatar} src="https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=5828015203933188&height=50&width=50&ext=1676768697&hash=AeQLBxHbv0GG71lIu98" />
        </Toolbar>
      </AppBar>

      {/* side drawer */}
      <Drawer
        className={classes.drawer}
        variant="persistent"
        classes={{ paper: classes.drawerPaper }}
        anchor="left"
        open={open}
      >
        <DrawerHeader>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
          </IconButton>
        </DrawerHeader>

        {/* links/list section */}
        <List>
          {menuItems.map((item) => (
            <ListItem 
              button 
              key={item.text} 
              onClick={() => history(item.path)}
              className={location.pathname === item.path ? classes.active : undefined}
            >
              <ListItemIcon>{item.icon}</ListItemIcon>
              <ListItemText primary={item.text} />
            </ListItem>
          ))}
        </List>
        
      </Drawer>

      {/* main content */}
      <Main open={open}>
      <DrawerHeader />
      {/* <div className={classes.page}>  */}
         {/* <div className={classes.toolbar}></div> */}
        { children }
      {/* </div>  */}
      </Main>
    </div>
      

  )
}
export default Layout;