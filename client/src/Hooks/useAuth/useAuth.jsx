import React, { useContext } from "react";
import {authContext} from '../../Shared/contexts';

export default function useAuth() {
    return useContext(authContext);
};