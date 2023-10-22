import { createBrowserRouter } from "react-router-dom";
import MainLayout from "@components/layouts/main.layout";
const RouterConfig = createBrowserRouter([
  {
    path: "/",
    Component: MainLayout,
    
  },
],{
  basename: "/app"
});

export default RouterConfig;