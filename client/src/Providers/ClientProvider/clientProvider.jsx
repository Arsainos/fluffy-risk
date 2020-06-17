import React from 'react';
import {clientContext} from '../../Shared/contexts';
import useClientProvider from '../../Hooks/useClientProvider/useClientProvider';

export default function AuthProvider({ children }) {
    const client = useClientProvider();
    return <clientContext.Provider value={client}>{children}</clientContext.Provider>;
}