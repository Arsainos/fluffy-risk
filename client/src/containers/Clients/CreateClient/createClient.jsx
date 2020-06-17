import React from 'react';

// import components
import Client from '../Client/client';

// import custom hooks
import useClient from '../../../Hooks/useClient/useClient';

export default function CreateClient() {
    useClient().clearClient();
    
    return (
        <Client type={'create'} />
    )
}