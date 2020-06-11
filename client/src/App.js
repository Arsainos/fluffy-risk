import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';

// import components
import Layout from './components/Layout/Layout';

function App() {
  return (
    <Layout>
        <p>Hello world</p>
    </Layout>
  );
}

export default App;
