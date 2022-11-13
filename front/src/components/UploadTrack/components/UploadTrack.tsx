import { Button, TextField } from '@mui/material'
import axios from 'axios';
import React, { useState } from 'react'
import Layout from '../../Common/components/Layout'


const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});


const UploadTrack = () => {
  const [color, setColor] = useState<string | undefined>(undefined)
  const [spotifyId, setSpotifyId] = useState<string | undefined>(undefined)
  const getMainPlaylist = () => {
    console.log(sessionStorage.getItem("token"));
          instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(sessionStorage.getItem("token") ?? ""))
        instance.post(process.env.REACT_APP_API_URL + "/Spotify",{link:color})
          .then(res => {
            console.log(res.data)
            setSpotifyId(res.data)
          })
          .catch(err => {
            console.log(err);
          });
          }
        

  return (
    <>    
      <Layout/>
      Paste link to track here < br />
      <TextField onChange={(event:any) => setColor(event.target.value)} id="outlined-basic" label="Outlined" variant="outlined" />< br />
      {color ? <p>Your link: {color}</p> : <></> }
      <Button onClick={()=>{getMainPlaylist()}}>Check</Button>
      {spotifyId ? 
      <>
      <p>You added: </p>
      {spotifyWiget(spotifyId)} 
      </>
      : <></>}
    </>

  )
}

export default UploadTrack

const spotifyWiget = (id:string) => {
  const  link ="".concat("https://open.spotify.com/embed/track/",id,"?utm_source=generator") 
  console.log(link);
  return <iframe  
      //style = {{style:"border-radius:12px"}} 
      src={link}
      width="100%" 
      height="122" 
      frameBorder="0" 
      //allowFullScreen="" 
      allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" 
      loading="lazy">

    </iframe>
  
}
