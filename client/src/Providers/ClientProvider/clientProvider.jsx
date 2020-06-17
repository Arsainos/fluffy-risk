import React from 'react';
import {clientContext} from '../../Shared/contexts';
import useClientProvider from '../../Hooks/useClientProvider/useClientProvider';

export default function ClientProvider({ children }) {
    const auth = useClientProvider();
    return <clientContext.Provider value={auth}>{children}</clientContext.Provider>;
}