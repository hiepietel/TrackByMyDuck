
import React, { useEffect, useState } from 'react'
import Container from '@material-ui/core/Container'
import Masonry from 'react-masonry-css'
import axios from "axios";
import TrackCard from '../UploadTrack/components/TrackCard';
import api from "./../../config/configAxios"
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';


const instance = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    // timeout: 1000,
    //headers = 
    //headers: new HttpHeaders().set("Authorization", "bearer BQDYhLLQv-daoM1vhdX2DzJ5DThBrbuzEis0WWdXDpCwvMkHkY…HJ0kY6PDJkdaz4zOFxLJOhP_UCe0D-US4voixjhitMHcH5Hgs")
  });
  
  const breakpoints = {
    default: 3,
    1100: 2,
    700: 1
  };

const Feed :React.FC= () => {
    const [tracks, setTracks] = useState<any[]>([]);

    useEffect(() => {
      api.get("/api/Track")
          .then(res => {
            console.log(res.data)
            setTracks(res.data);
          })
          .catch(err => {
            console.log(err);
          });
    }, [])


    return (
        <Container>
          {/* <Masonry
            breakpointCols={breakpoints}
            className="my-masonry-grid"
            columnClassName="my-masonry-grid_column"> */}
                <List
      sx={{ width: '100%',  bgcolor: 'background.paper' }}
      subheader={""}  
    >
            {tracks.map(note => (
              <div key={note.id}>
                <ListItem alignItems="center">
                <TrackCard track={note} />
                </ListItem>
                {/* <NoteCard note={note} handleDelete={handleDelete} /> */}
              </div>
            ))}
          {/* </Masonry> */}
          </List>
        </Container>
      )
        }
export default Feed;