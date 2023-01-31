import axios, { AxiosHeaders, AxiosRequestConfig, AxiosResponse, InternalAxiosRequestConfig } from "axios";

const { REACT_APP_API_URL } = process.env;

const api = () => {
  const defaultOptions = {
    baseURL: REACT_APP_API_URL,
    headers: {
      'Content-Type': 'application/json',
    }
  };

  // Create instance
  let instance = axios.create(defaultOptions);

  // Set the AUTH token for any request
    instance?.interceptors.request.use((config: InternalAxiosRequestConfig) => {

    const token = sessionStorage.getItem("token");
    
    (config.headers as AxiosHeaders).set("Authorization", token ? `${token}` : '');
    // if(!!config.headers) {
    //   config.headers= {
    //     Authorization :  token ? `${token}` : ''
    //   }
    //   config.headers['Access-Control-Max-Age'] = 0;
    // }
    
    return config;
  });

  // return response
  instance.interceptors.response.use((response: AxiosResponse) => response)

  return instance;
};

export default api();