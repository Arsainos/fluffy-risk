import { useContext } from "react";
import { clientContext } from '../../Shared/contexts';

export default function useClient() {
    return useContext(clientContext);
};