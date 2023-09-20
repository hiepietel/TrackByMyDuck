import React, { useEffect } from "react";
import Layout from "./Layout";
import { useLocation } from "react-router-dom";
import api from "../../../../config/configAxios";
interface LayoutProps {
  children: any;
}

const MainLayout: React.FC<LayoutProps> = ({ children }) => {
  const location = useLocation();
  const [userinfo, setUserInfo] = React.useState<any>({});
  const [aoutheticated, setAutheticated] = React.useState<boolean>(false);
  useEffect(() => {
    if (location.pathname === "/main" || location.pathname === "/create") {
     // console.log(location.pathname);
      api
        .get("api/Auth/user-info")
        .then((res: any) => {
          console.log(res.data);
          setUserInfo(res.data);
          setAutheticated(true);
        })
        .catch((err: any) => {
          console.log(err);
        });
    }
    if(location.pathname === "/")
    {
      console.log(location.pathname)
      setAutheticated(false)
    }

  }, [location.pathname]);

  if (aoutheticated)
    return <Layout children={children} userInfo={userinfo}></Layout>;
  else return <>{children}</>;
};

export default MainLayout;
