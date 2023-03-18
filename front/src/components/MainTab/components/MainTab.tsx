import axios from "axios";
import React from "react";

const instance = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    // timeout: 1000,
    //headers = 
    //headers: new HttpHeaders().set("Authorization", "bearer BQDYhLLQv-daoM1vhdX2DzJ5DThBrbuzEis0WWdXDpCwvMkHkY…HJ0kY6PDJkdaz4zOFxLJOhP_UCe0D-US4voixjhitMHcH5Hgs")
  });
  

const MainTab11 :React.FC= () => {
  
    return (
        <></>
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