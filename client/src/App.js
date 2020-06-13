import React, { Suspense } from 'react';

// import components
import Layout from './components/Layout/Layout';
import Spinner from './components/UI/Spinner/spinner';
import Routes from './Routes/routes';

function App() {
  
  return (
    <Layout>
      <Suspense fallback={Spinner}>
        <Routes />
      </Suspense>
    </Layout>
  );
}

export default App;
