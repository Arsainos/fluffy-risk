import React, { lazy } from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';

// lazy loading and code splitting for containers
const Home = lazy(() => import('../containers/Home/home'));
const Clients = lazy(() => import('../containers/Clients/clients'));
const Ranking = lazy(() => import('../containers/Ranking/ranking'));
const Srp = lazy(() => import('../containers/SRP/srp'));
const Users = lazy(() => import('../containers/Users/users'));

export default function Routes() {
    return(
        <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/Home" component={Home} />
            <Route path="/Ranks" component={Ranking} />
            <Route path="/Clients" component={Clients} />
            <Route path="/Srp" component={Srp} />
            <Route path="/Users" component={Users} />
        </Switch>
    )
};