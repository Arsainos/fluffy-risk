import {authContext} from '../../Shared/contexts';
import useProvideAuth from '../../Hooks/useAuthProvider/useAuthProvider';

export default function AuthProvider({ children }) {
    const auth = useProvideAuth();
    return <authContext.Provider value={auth}>{children}</authContext.Provider>;
}