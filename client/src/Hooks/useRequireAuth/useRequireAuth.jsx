import React, {useEffect} from 'react';

import useAuth from '../useAuth/useAuth';
import useRouter from '../useRouter/useRouter';

export default function useRequireAuth(redirectUrl = '/singin') {
    const auth = useAuth();
    const router = useRouter();

    useEffect(() => {
        if (auth.user === false){
            router.push(redirectUrl);
        }
    }, [auth, router]);
        
      return auth;
}