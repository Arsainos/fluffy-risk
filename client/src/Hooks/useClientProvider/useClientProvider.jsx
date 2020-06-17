import { useState } from "react";

import useRouter from '../useRouter/useRouter';

import {clientsMockData} from '../../mocks/data/clients';

export default function useAuthProvider() {
    const [client, setClient] = useState(null);
  
    // Set client to use in context
    const setClientToContext = (clientInfo) => {
        setClient(clientInfo);
    };

    const getClient = (clientId) => {
        const searchClient = clientsMockData.filter((current) => current.id === Number.parseInt(clientId))[0];
        if(searchClient) {
            setClient(searchClient);
            return true;
        } else return false;    
    };

    const clearClient = () => {
        setClient(null);
    }

    const checkClientSet = (clientId) => {
        if(client === null || client === false) {
            return getClient(clientId);
        } else {
            if(Number.parseInt(clientId) !== client.id) {
                return getClient(clientId);
            }
        }

        return true;
    }

    const createClient = (clientData) => {
        clientsMockData.push({
            id: clientsMockData[clientsMockData.length - 1].id + 1,
            clientName: clientData.clientName,
            clientInn: clientData.clientInn,
            clientHolding: clientData.clientHolding
        });
    }
    
    // Return the client object and clients methods
    return {
        client,
        setClientToContext,
        getClient,
        checkClientSet,
        clearClient,
        createClient
    };
}