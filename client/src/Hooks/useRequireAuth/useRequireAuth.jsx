import React, {useEffect} from 'react';

import useAuth from '../useAuth/useAuth';
import useRouter from '../useRouter/useRouter';

export default function useRequireAuth(redirectUrl = '/signin') {
    const auth = useAuth();
    const router = useRouter();

    useEffect(() => {
        if (auth.user === false || auth.user === null){
            router.push(redirectUrl);
        }
    }, [auth, router]);
        
      return auth;
}