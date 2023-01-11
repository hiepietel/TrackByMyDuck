import React from 'react'
import Card from '@material-ui/core/Card'
import CardHeader from '@material-ui/core/CardHeader'
import CardContent from '@material-ui/core/CardContent'
import IconButton from '@material-ui/core/IconButton'
import Typography from '@material-ui/core/Typography'
import DeleteOutlined from '@material-ui/icons/DeleteOutlined'
import { CardMedia, makeStyles } from '@material-ui/core'
import Avatar from '@material-ui/core/Avatar'
import { yellow, green, pink, blue } from '@material-ui/core/colors'

interface TrackCardProps{
    track: any
}

const TrackCard :React.FC<TrackCardProps>= ({track}) => {
    console.log(track)
    return (
        <div>
          <Card elevation={1}>
            <CardHeader
              avatar={
                <Avatar className={"classes.avatar"}>
                  {/* {"".toUpperCase();} */}
                </Avatar>}
              action={
                <IconButton onClick={() => {}}>
                  <DeleteOutlined />
                </IconButton>
              }
              title={track.name}
              subheader={"note.category"}
            />

            <CardContent>
              <Typography variant="body2" color="textSecondary">
                <img src={track.albumUrl}/>
              </Typography>
            </CardContent>
          </Card>
        </div>
    )
}

export default TrackCard