import React, { lazy, Suspense } from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';

// import components
import Layout from './components/Layout/Layout';
import Spinner from './components/UI/Spinner/spinner';

// lazy loading and code splitting for containers
const Clients = lazy(() => import('./containers/Clients/clients'));
const Ranking = lazy(() => import('./containers/Ranking/ranking'));
const Srp = lazy(() => import('./containers/SRP/srp'));
const Users = lazy(() => import('./containers/Users/users'));

function App() {
  return (
    <Layout>
        <Suspense fallback={Spinner}>
          <Switch>
            <Route path="/Ranks" component={Ranking} />
            <Route path="/Clients" component={Clients} />
            <Route path="/Srp" component={Srp} />
            <Route path="/Users" component={Users} />
          </Switch>
        </Suspense>
    </Layout>
  );
}

export default App;
