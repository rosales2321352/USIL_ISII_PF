import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Pedidos } from "./components/Pedidos/Pedidos";
import { Prospecto } from "./components/Pedidos/Prospecto";
import { OrdenDeCompra } from "./components/Pedidos/OrdenDeCompra";
import { Finalizado } from "./components/Pedidos/Finalizado";
import { Cancelado } from "./components/Pedidos/Cancelado";


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
        path: '/prospecto',
        element: <Prospecto />
    },
    {
        path: '/orden-de-compra',
        element: <OrdenDeCompra />
    },
    {
        path: '/finalizado',
        element: <Finalizado />
    },
    {
        path: '/cancelado',
        element: <Cancelado />
    }
];

export default AppRoutes;
