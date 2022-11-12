import axios from "axios";
import React, { useState } from "react";

const instance = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    // timeout: 1000,
    //headers = 
    //headers: new HttpHeaders().set("Authorization", "bearer BQDYhLLQv-daoM1vhdX2DzJ5DThBrbuzEis0WWdXDpCwvMkHkY…HJ0kY6PDJkdaz4zOFxLJOhP_UCe0D-US4voixjhitMHcH5Hgs")
  });
  
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
  
          var ids :number[]= []
          res.data.map((x:any) => {
            console.log(x.id)
            ids.push(x.id)
           })
           console.log(ids);
          setData(ids)
        })
    
    }
  
    return (
      <div style={{height: "1000px"}}>MainTab
        <button onClick={() => {
          getMainPlaylist();
          console.log(data);
        }
        } >
          Click me
          </button>
            
         <h1>{data.length > 0 ? data.map((x:number)=> {
          console.log(x);
          return spotifyWiget(x) }): <></>}</h1> 
         By
        {/* {data != undefined ? data : data.} */}
      </div>
      
    )
  }

  const spotifyWiget = (id:number) => {
    const  link ="".concat("https://open.spotify.com/embed/track/",id.toString(),"?utm_source=generator") 
    console.log(link);
    return <iframe  
        //style = {{style:"border-radius:12px"}} 
        src={link}
        width="100%" 
        height="152" 
        frameBorder="0" 
        //allowFullScreen="" 
        allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" 
        loading="lazy">
  
      </iframe>
    
  }

  export default MainTab11