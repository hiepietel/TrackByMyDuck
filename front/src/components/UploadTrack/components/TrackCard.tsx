import React from 'react'
import Card from '@material-ui/core/Card'
import CardHeader from '@material-ui/core/CardHeader'
import CardContent from '@material-ui/core/CardContent'
import IconButton from '@material-ui/core/IconButton'
import Typography from '@material-ui/core/Typography'
import DeleteOutlined from '@material-ui/icons/DeleteOutlined'
import { Box, CardMedia, Grid, makeStyles } from '@material-ui/core'
import Avatar from '@material-ui/core/Avatar'
import { yellow, green, pink, blue } from '@material-ui/core/colors'

interface TrackCardProps{
    track: any
}

const TrackCard :React.FC<TrackCardProps>= ({track}) => {

    return (
<Grid container justify = "center">
          <Card elevation={5}>
            {/* <CardHeader
              avatar={
                <Avatar className={"classes.avatar"}>
                </Avatar>}
              // action={
              //   <IconButton onClick={() => {}}>
              //     <DeleteOutlined />
              //   </IconButton>
              // }
              title={track.name}
              //subheader={"note.category"}
            />    */}
          <Box sx={{ display: 'flex' }}>
          <div>
          <CardHeader
              avatar={
                <Avatar className={"classes.avatar"}>
                </Avatar>}
              // action={
              //   <IconButton onClick={() => {}}>
              //     <DeleteOutlined />
              //   </IconButton>
              // }
              title={track.name}
              //subheader={"note.category"}
            />   
              <CardContent style={{ flex: '1 0 auto', width: 320 }}>
                <Typography component="div" variant="h5">
                  {track.name}
                </Typography>
                <Typography variant="subtitle1"  component="div">
                  Mac Miller
                </Typography>
                <video controls={true} autoPlay={false} style={{height: 40, width: "90%"}}>
                  <source src="https://p.scdn.co/mp3-preview/ece7de9fa4f1694b5775fd6a4e28b87eccdfd5d5?cid=0677be572f8049d083932db39f8f77f5" type="audio/mpeg" />

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