import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, HashRouter, Switch, Route} from 'react-router-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';

// import componenst
import AuthProvider from './Providers/AuthProvider/authProvider';
import ClientProvider from './Providers/ClientProvider/clientProvider';
import SignInPage from './containers/Auth/auth';

ReactDOM.render(
  <React.StrictMode>
    <HashRouter>
      <AuthProvider>
        <ClientProvider>
          <Switch>
            <Route path="/signin">
              <SignInPage />
            </Route>
            <Route>
              <App />
            </Route>
          </Switch>   
        </ClientProvider>     
      </AuthProvider>
    </HashRouter>   
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
