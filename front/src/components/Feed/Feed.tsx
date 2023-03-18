import React, { useEffect, useState } from 'react'
import Container from '@material-ui/core/Container'
import TrackCard from '../UploadTrack/components/TrackCard';
import api from "./../../config/configAxios"
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';

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