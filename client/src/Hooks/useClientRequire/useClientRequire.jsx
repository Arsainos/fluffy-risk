import {useEffect} from 'react';

import useClient from '../useClient/useClient';
import useRouter from '../useRouter/useRouter';

export default function useRequireClient(redirectUrl = '/Clients/AllClients') {
    const client = useClient(); 
    const router = useRouter();

    useEffect(() => {
        if(!client.checkClientSet(router.query.clientId))
        {           
            return router.push(redirectUrl);
        }
    }, [router])

    return {
        client
    };
}