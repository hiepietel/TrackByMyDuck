import { Pagination, Paper, Stack, styled, Table, TableBody, TableContainer, TableRow } from "@mui/material";
import axios from "axios";
import React, { useState } from "react";
import Layout from "../../Common/components/Layout";
import { ISpotifyTrack } from "../interfaces/ISpotifyTrack";
import TrackTile from "./TrackTile";

const instance = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    // timeout: 1000,
    //headers = 
    //headers: new HttpHeaders().set("Authorization", "bearer BQDYhLLQv-daoM1vhdX2DzJ5DThBrbuzEis0WWdXDpCwvMkHkY…HJ0kY6PDJkdaz4zOFxLJOhP_UCe0D-US4voixjhitMHcH5Hgs")
  });
  
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }));

const MainTab11 :React.FC= () => {

    const [data, setData] = useState<any[]>([]);
    var sData  = undefined
  
  
    const getMainPlaylist = () => {
  console.log(sessionStorage.getItem("token"));
        instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(sessionStorage.getItem("token") ?? ""))
      instance.get(process.env.REACT_APP_API_URL + "/Spotify")
        .then(res => {
          console.log(res.data)
          setData(res.data)
  
          var ids :ISpotifyTrack[]= []
          res.data.map((x:ISpotifyTrack) => {
            console.log(x.spotifyId)
            ids.push({
              spotifyId: x.spotifyId,
            addedBy: x.addedBy,
          addedDate: x.addedDate})
           })
           console.log(ids);
          setData(ids)
        })
    
    }
  
    return (
      <Stack
  direction="column"
  justifyContent="space-evenly"
  alignItems="stretch"
  spacing={1}
>
  <Item>  <button onClick={() => {
          getMainPlaylist();
          console.log(data);
        }
        } >
          Click me
          </button></Item>
            <TableContainer component={Paper}>
      <Table sx={{ minWidth: 500 }} aria-label="simple table">
      <TableBody>
  
        {data.length > 0 ? data.map((x:ISpotifyTrack)=> {
          console.log(x);
          return <TableRow>
            <TrackTile spotifyId={x.spotifyId} addedBy={x.addedBy}/>
            </TableRow> }): <></>}
        </TableBody>
        </Table>
        <Pagination count={10} />
      </TableContainer>

         <Layout /> 
      </Stack> 
    )
  }

  const spotifyWiget = (id:number) => {
    const  link ="".concat("https://open.spotify.com/embed/track/",id.toString(),"?utm_source=generator") 
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

  export default MainTab11