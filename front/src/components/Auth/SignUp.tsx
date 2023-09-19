import { Box, Button, Container, TextField, Typography } from '@material-ui/core';
import axios from 'axios';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';

const instance = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
  });

  


  const SignUpFromApi = ( email: string, password: string) =>{
    axios.post(process.env.REACT_APP_API_URL + "/api/auth/sign-up",{
    email: email,
    name: email,
    password: password
}
    )
    .then(res => {
      console.log(res.data)
      //sessionStorage.setItem("token", `bearer ${res.data.accessToken}`);
      sessionStorage.setItem("token", `bearer ${res.data.accessToken}`);
      instance.defaults.headers.common['Authorization'] = unescape(encodeURIComponent(`bearer ${res.data}` ));
    })
  }




const SignUp = () => {

    const navigate = useNavigate();
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e: any) => {
        e.preventDefault();
    
        SignUpFromApi(name, password)
    
        // You can add your login logic here, e.g., send a request to your backend API.
        console.log('Email:', name);
        alert("account created")
        //navigate("/main") 
       // console.log('Password:', password);
      };

  return (
    <Container maxWidth="xs">
    <form onSubmit={handleSubmit}>
      <Typography variant="h5" align="center" gutterBottom>
        SignUp
      </Typography>
      <Box sx={{ mt: 3 }}>
        <TextField
        //   type="email"
          label="Name"
          variant="outlined"
          fullWidth
          required
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </Box>
      <Box sx={{ mt: 2 }}>
        <TextField
          type="password"
          label="Password"
          variant="outlined"
          fullWidth
          required
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Box>
      <Box sx={{ mt: 3 }}>
        <Button type="submit" variant="contained" color="primary" fullWidth>
          Sign Up
        </Button>
      </Box>
    </form>
  </Container>
  )
}

export default SignUp