import React from 'react';

// import routes for nested pages
import {SrpRoutes as Routes} from '../../Routes/routes';

export default function Srp() {
    return (
        <React.Fragment>
            <h1>Сигналы</h1>
            <Routes />
        </React.Fragment>
    )
}