import 'bootstrap/dist/css/bootstrap.min.css';

import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './components/app';
import Header from './components/header';

const rootElement = document.getElementById('root');

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter basename="/">
      <Header />
      <App />
    </BrowserRouter>
  </React.StrictMode>,
  rootElement
);