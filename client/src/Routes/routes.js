import React, { lazy } from 'react';
import { Route, Switch, Redirect, useRouteMatch } from 'react-router-dom';

// lazy loading and code splitting for containers
const Home = lazy(() => import('../containers/Home/home'));
const Clients = lazy(() => import('../containers/Clients/clients'));
const Ranking = lazy(() => import('../containers/Ranking/ranking'));
const Srp = lazy(() => import('../containers/SRP/srp'));
const Users = lazy(() => import('../containers/Users/users'));
const PageNotFound = lazy(() => import('../containers/404/404'));

export default function Routes() {
    return(   
        <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/Home" component={Home} />
            <Route path="/Ranks" component={Ranking} />
            <Route path="/Clients" component={Clients} />
            <Route path="/Srp" component={Srp} />
            <Route path="/Users" component={Users} />
            <Route path="/404" component={PageNotFound} />
            <Route path="*">
                <Redirect to="/404" />
            </Route>
        </Switch>       
    )
};

// lazy loading and code splitting for Clients Containers
const AllClients = lazy(() => import('../containers/Clients/AllClients/allClients'));
const CreateClient = lazy(() => import('../containers/Clients/CreateClient/createClient'));
const Client = lazy(() => import('../containers/Clients/Client/client'));

export function ClientRoutes() {
    let {path} = useRouteMatch();

    return(
        <Switch>
            <Route path={`${path}/allClients`} component={AllClients} />
            <Route path={`${path}/newClient`} component={CreateClient} />
            <Route path={`${path}/:clientId`} component={Client} />
            <Redirect push from={`${path}/*`} to="/404" />
        </Switch>
    )
};

// lazy loading and code splitting for Ranking Containers
const CreateRank = lazy(() => import('../containers/Ranking/CreateRank/createRank'));
const GroupRanks = lazy(() => import('../containers/Ranking/GroupRanks/groupRanks'));
const MyRanks = lazy(() => import('../containers/Ranking/MyRanks/myRanks'));

export function RankingRoutes() {
    let {path} = useRouteMatch();

    return(
        <Switch>
            <Route path={`${path}/createRank`} component={CreateRank} />
            <Route path={`${path}/myRanks`} component={MyRanks} />
            <Route path={`${path}/groupRanks`} component={GroupRanks} />
            <Redirect from={`${path}/*`} to="/404" />
        </Switch>
    )
};

// lazy loading and code splitting for SRP Containers
const ClientMonitoring = lazy(() => import('../containers/SRP/ClientMonitoring/clientMonitoring'));
const ClientSignals = lazy(() => import('../containers/SRP/ClientSignals/clientSignlas'));

export function SrpRoutes() {
    let {path} = useRouteMatch();

    return (
        <Switch>
            <Route path={`${path}/clientMonitoring`} component={ClientMonitoring} />
            <Route path={`${path}/clientsSignals`} component={ClientSignals} />
            <Redirect from={`${path}/*`} to="/404" />
        </Switch>
    )
};

// lazy loading and code splitting for Users Containers
const Account = lazy(() => import('../containers/Users/Account/account'));
const AllUSers = lazy(() => import('../containers/Users/AllUsers/allUsers'));
const Groups = lazy(() => import('../containers/Users/Groups/groups'));

export function UserRoutes() {
    let {path} = useRouteMatch();

    return (
        <Switch>
            <Route path={`${path}/account`} component={Account} />
            <Route path={`${path}/usersByGroup`} component={Groups} />
            <Route path={`${path}/allUsers`} component={AllUSers} />
            <Redirect from={`${path}/*`} to="/404" />
        </Switch>
    )
}