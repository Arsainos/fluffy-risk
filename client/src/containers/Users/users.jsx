import React from 'react';

// import routes for nested pages
import {UserRoutes as Routes} from '../../Routes/routes';

export default function Users() {
    return (
        <React.Fragment>
            <h1>Пользователи</h1>
            <Routes />
        </React.Fragment>
    )
}