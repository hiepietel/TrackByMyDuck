import React, { useState } from 'react'
import Typography from '@material-ui/core/Typography'
import Button from '@material-ui/core/Button'
import Container from '@material-ui/core/Container'
import { makeStyles } from '@material-ui/core'
import TextField from '@material-ui/core/TextField'
import TrackCard from './TrackCard'
import { useNavigate } from 'react-router-dom'
import api from "./../../../config/configAxios"

const useStyles = makeStyles({
    field: {
      marginTop: 20,
      marginBottom: 20,
      display: 'block'
    }
  })
  
const UploadTrack:React.FC = () => {
  const history = useNavigate ()
  const classes = useStyles()
  const [title, setTitle] = useState('')
  const [isTrackValidated, setTrackValidated] = useState(false);
  const [track, setTrack] = useState<any>({});
  
  const getMainPlaylist = (link: string) => {
          api.post("/api/Track/check-track", {Link:title})
          .then(res => {
            console.log(res.data)
            setTrack(res.data)
            setTrackValidated(true);
          })
          .catch(err => {
            console.log(err);
          });

    }
  
  const handleSubmit = () => {
    if(title !== ""){
        api.post("/api/Track/add-track",{Link:title})
        .then(res => {
            history("main")
          console.log(res.data)
        })
        .catch(err => {
          console.log(err);
        });
    }    
  }
  
  return (
  <Container >
      <Typography
        variant="h6" 
        color="textSecondary"
        component="h2"
        gutterBottom
      >
        Upload track to trackByMyDuck
      </Typography>
      
      <form noValidate autoComplete="off" onSubmit={handleSubmit}>

        {isTrackValidated === false ? 
          <>
            <TextField className={classes.field}
              onChange={(e) => { setTitle(e.target.value) }}
              label="Track link" 
              variant="outlined" 
              color="secondary" 
              fullWidth
              required
              error={false}
            />
            <Button
              //type="submit" 
              color="secondary" 
              variant="contained"
              onClick={(e: any) => {getMainPlaylist(e.target.value);}}
              //endIcon={<KeyboardArrowRightIcon />}
              >
                Check link
            </Button>
          </>
        :
          <>
            <TrackCard track={track}/>
            <Button
              type="submit" 
              color="secondary" 
              variant="contained"
            >
              Add 
            </Button>
          </>
         }
      </form>     
    </Container>
  )
}

export default UploadTrack