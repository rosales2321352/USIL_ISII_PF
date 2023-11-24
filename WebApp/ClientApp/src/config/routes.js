import { createBrowserRouter } from "react-router-dom";
import SecurityLayout from "../components/layouts/security/security.layout";
import MainLayout from "../components/layouts/main.layout";
/***/
import { PedidosView } from "../components/views/Pedidos/pedidos.view";
import { ProspectoView } from "../components/views/Pedidos/prospecto.view";
import { OrdenCompraView } from "../components/views/Pedidos/ordencompra.view";
import { FinalizadoView } from "../components/views/Pedidos/finalizado.view";
import { CanceladoView } from "../components/views/Pedidos/cancelado.view";
import { HistorialPedidos } from "../components/views/Pedidos/historialPedidos";
/***/
import ChatView from "../components/views/Chats/chat.view";
import Contactos from "../components/views/Contactos/contactos";
/***/
import { EventBarView } from "../components/views/Events/eventBar.view"

const AppRoutes = createBrowserRouter([
  {
    path: "/",
    Component: SecurityLayout,
    children: [
      {
        Component: MainLayout,
        children: [
          {
            index: true,
            Component: Contactos
          },
          {
            path: '/pedidos',
            Component: PedidosView
          },
          {
              path: '/prospecto',
              Component: ProspectoView
          },
          {
              path: '/orden-de-compra',
              Component: OrdenCompraView
          },
          {
              path: '/finalizado',
              Component: FinalizadoView
          },
          {
              path: '/cancelado',
              Component: CanceladoView
          },
          {
              path: '/chat',
              Component: ChatView
          },
          {
              path:'/contactos',
              Component: Contactos
          },
          {
              path: '/events',
              Component: EventBarView
          },
          {
              path: '/historialPedidos',
              Component: HistorialPedidos
          },
        ]
      }
    ]
  }
])

export default AppRoutes;