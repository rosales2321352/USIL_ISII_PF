import React, { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { RouterProvider } from 'react-router-dom';
import AppRoutes from './config/routes';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';
import ClientState from './context/Client/client.state.context';
import 'bootstrap/dist/css/bootstrap.css';
import './assets/css/main.css'
import './assets/GlobalStyles.css';
import { ThemeProvider } from '@mui/material/styles';
import ThemeDefault from './theme/theme';
import EventState from './context/Event/event.state.context';

const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
  <StrictMode>
    <ThemeProvider theme={ThemeDefault}>
      <ClientState>
        <EventState>
          <RouterProvider router={AppRoutes} />
        </EventState>
      </ClientState>
    </ThemeProvider>
  </StrictMode>
  
)

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
