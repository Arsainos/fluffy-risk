import React from 'react';

// import routes for nesting pages
import {ClientRoutes as Routes} from '../../Routes/routes';

export default function Clients() {
    return (
        <React.Fragment>
            <h1>Клиенты</h1>
            <Routes />
        </React.Fragment>     
    )
}