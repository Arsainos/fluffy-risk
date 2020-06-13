import React, { lazy, Suspense } from 'react';
import { Route, Switch, Redirect, useRouteMatch } from 'react-router-dom';

// import components
import Layout from './components/Layout/Layout';
import Spinner from './components/UI/Spinner/spinner';
import Routes from './Routes/routes';
import useRequireAuth from './Hooks/useRequireAuth/useRequireAuth';

function App() {
  const auth = useRequireAuth();

  return (
    <Layout>   
      <Suspense fallback={<Spinner />}>     
        <Routes />   
      </Suspense>        
    </Layout>
  );
}

export default App;
