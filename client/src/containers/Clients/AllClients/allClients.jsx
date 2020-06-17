import React from 'react';

// import components
import MuiTable from '../../../components/UI/Table/table';
import Edit from '@material-ui/icons/Edit';
import { Link as RouterLink } from 'react-router-dom';

// import custom hooks
import useRouter from '../../../Hooks/useRouter/useRouter';
import useClient from '../../../Hooks/useClient/useClient';

// import data
import {clientsMockData} from '../../../mocks/data/clients';

export default function AllClients() {
    const router = useRouter();
    const client = useClient();
    
    return (
        <MuiTable 
            columns={[

                { title: 'ID' , field: 'id'},
                { 
                    title: 'Имя клиента',
                    field: 'clientName',
                    render: rowData => 
                        <div>
                            <RouterLink to={`/Clients/${rowData.id}?action=show`}
                                onClick={() => {
                                    client.setClientToContext(rowData);
                                }}
                            >
                                {rowData.clientName}
                            </RouterLink>
                        </div>
                },
                { title: 'ИНН', field: 'clientInn'},
                { title: 'Группа', field: 'clientHolding'},
                {
                    title: 'Переходы',
                    field: 'references',
                    render: rowData => <div><a href={`#${rowData.id}`}>Рейтингование</a><br/><a href={`#${rowData.id}`}>СРП</a></div>
                }
            ]}
            data={clientsMockData}
            title={'Все клиенты'}
            actions={[
                {
                  icon: Edit,
                  tooltip: 'Редактирование',
                  onClick: (event, rowData) => {
                    client.setClientToContext(rowData);
                    router.push(`/Clients/${rowData.id}?action=edit`);
                  }
                }
              ]}
        />
    )
}