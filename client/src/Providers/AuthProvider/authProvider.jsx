import React from 'react';
import {authContext} from '../../Shared/contexts';
import useAuthProvider from '../../Hooks/useAuthProvider/useAuthProvider';

export default function AuthProvider({ children }) {
    const auth = useAuthProvider();
    return <authContext.Provider value={auth}>{children}</authContext.Provider>;
}