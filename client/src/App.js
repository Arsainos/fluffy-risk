import React, { lazy, Suspense } from 'react';
import { Route, Switch, Redirect, useRouteMatch } from 'react-router-dom';

// import components
import Layout from './components/Layout/Layout';
import Spinner from './components/UI/Spinner/spinner';
import Routes from './Routes/routes';
import WaitForValidation from './containers/sessionValidation/sessionValidation';

// import custom hooks
import useRequireAuth from './Hooks/useRequireAuth/useRequireAuth';


function App() {
  const {auth} = useRequireAuth();

  const appContent = auth.user !== null && auth.user !== false ? 
  (
    <Layout>   
      <Suspense fallback={<Spinner />}>     
        <Routes />   
      </Suspense>        
    </Layout>
  ) : 
  (
    <WaitForValidation />
  );

  return (
    <React.Fragment>
      {appContent}
    </React.Fragment>
  );
}

export default App;
