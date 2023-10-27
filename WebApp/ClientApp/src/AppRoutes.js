import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Pedidos } from "./components/Pedidos";
import { Contactos } from "./components/Contactos";


const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/pedidos',
        element: <Pedidos />
    },
    {
        path: '/Contactos',
    element: <Contactos />
    }
];

export default AppRoutes;
