import React from 'react';

// import Routes for nested pages
import {RankingRoutes as Routes} from '../../Routes/routes';

export default function Ranking() {
    return (
        <React.Fragment>
            <h1>Анкетирование</h1>
            <Routes />
        </React.Fragment>     
    )
}