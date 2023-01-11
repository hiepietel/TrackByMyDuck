
import React, { useEffect, useState } from 'react'
import Container from '@material-ui/core/Container'
import Masonry from 'react-masonry-css'
import axios from "axios";
import TrackCard from '../UploadTrack/components/TrackCard';

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
        instance.get(process.env.REACT_APP_API_URL + "/api/Track",)
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
          <Masonry
            breakpointCols={breakpoints}
            className="my-masonry-grid"
            columnClassName="my-masonry-grid_column">
            {tracks.map(note => (
              <div key={note.id}>
                <TrackCard track={note} />
                {/* <NoteCard note={note} handleDelete={handleDelete} /> */}
              </div>
            ))}
          </Masonry>
        </Container>
      )
        }
export default Feed;