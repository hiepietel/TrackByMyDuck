import { Card, CardContent, CardHeader, Typography } from '@mui/material'
import React from 'react'


interface ITrackTileProps {
    spotifyId: number,
    addedBy:string
}

const TrackTile :React.FC<ITrackTileProps>= ({spotifyId, addedBy}) => {
  return (
    <Card sx={{ textAlign:"center", marginLeft: "10vh", marginRight:"10vh", paddingBottom:"1vh" }}>
      <CardContent>
      <Typography variant="body1" component="div">
      Added by {addedBy}
      </Typography>
        {spotifyWiget(spotifyId)}</CardContent>
      </Card>
    
  )
}

const spotifyWiget = (id:number) => {
    const  link ="".concat("https://open.spotify.com/embed/track/",id.toString(),"?utm_source=generator") 
    console.log(link);
    return <><iframe  
        //style = {{style:"border-radius:12px"}} 
        src={link}
        width="100%" 
        height="102" 
        frameBorder="0" 
        //allowFullScreen="" 
        allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" 
        loading="lazy">
  
      </iframe></>

    
  }

export default TrackTile