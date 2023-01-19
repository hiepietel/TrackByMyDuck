import React from 'react'
import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent'
import IconButton from '@material-ui/core/IconButton'
import Typography from '@material-ui/core/Typography'
import DeleteOutlined from '@material-ui/icons/DeleteOutlined'
import { Box, CardMedia, Grid, makeStyles } from '@material-ui/core'
import Avatar from '@material-ui/core/Avatar'
import { yellow, green, pink, blue } from '@material-ui/core/colors'
import { CardHeader, createTheme } from '@mui/material'

interface TrackCardProps{
    track: any
}

const TrackCard :React.FC<TrackCardProps>= ({track}) => {

  const theme = createTheme({
    components: {
      // Name of the component
      MuiCardHeader: {
        styleOverrides: {
          // Name of the slot
          root: {
            // Some CSS
            fontSize: '1rem',
            padding: "5px",
            margin: '0px',
            backgroundColor: '#B32D2C',
          },
        },
      },
    },
  });


    return (
<Grid container justifyContent = "center">
          <Card elevation={5}>
          <Box sx={{ display: 'flex' }}>
          <div>
          <CardHeader
            theme={theme}
              avatar={
                <Avatar className={"classes.avatar"}>
                </Avatar>}
              title={track.name}
              
              //subheader={"note.category"}
            />   
              <CardContent style={{ flex: '1 0 auto', width: 320 }}>
                <Typography component="div" variant="h5">
                  {track.name}
                </Typography>
                  {track.artists ? track.artists.map((note:any) => (
                    <Typography variant="subtitle1"  component="div">
                      {note}
                </Typography>

                  )) : <></>}
                
                <video controls={true} autoPlay={false} style={{height: 80, width: "90%"}}>
                  <source src={track.previewUrl} type="audio/mpeg" />

                  </video>
                  
          </CardContent>
          </div>
              <CardMedia
            component="img"
            style = {{ width: 320 }}
            image={track.imgHref}
            alt="Paella dish"
          />
            </Box>
          </Card>
          </Grid>
    )
}

export default TrackCard