import React from 'react';

// import components
import MuiTable from '../../../components/UI/Table/table';

// import data for table
import {clientsMockData} from '../../../mocks/data/clients';

export default function AllClients() {
    return (
        <MuiTable 
            columns={[
                { title: 'Имя клиента', field: 'clientName'},
                { title: 'ИНН', field: 'clientInn'},
                { title: 'Группа', field: 'clientHolding'}
            ]}
            data={clientsMockData}
            title={'Все клиенты'}
        />
    )
}