import {useEffect} from 'react';

import useAuth from '../useAuth/useAuth';
import useRouter from '../useRouter/useRouter';

export default function useRequireAuth(redirectUrl = '/signin') {
    const auth = useAuth(); 
    const router = useRouter();

    useEffect(() => {
        if(!auth.checkSignin())
        {
            return router.push(redirectUrl);
        }
    }, [])

    return {
        auth
    };
}