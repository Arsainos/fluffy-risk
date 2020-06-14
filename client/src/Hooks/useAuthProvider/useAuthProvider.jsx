import React, { useState } from "react";

import useRouter from '../useRouter/useRouter';

export default function useAuthProvider() {
    const [user, setUser] = useState(null);
    const [error, setError] = useState(null);
    const router = useRouter();
  
  // Wrap any web methods to signin user
  // just use admin/admin for testing
  const signin = (email, password) => {
    if(email === 'admin' && password === 'admin') {
        setUser({id:1, name:'admin'});
        setError(null);
        router.push('/Home');
    } else {
        setError('Не верно указан логин или пароль');
        setUser(false);
    }
  };

  const ldapSignin = (domain, user, password) => {
    if(domain === 'test' && user === 'admin' && password === 'admin') {
      setUser({id:1, name:'admin'});
      setError(null);
      router.push('/Home');
    } else {
      setError('Не верно указан логин, пароль или название AD')
      setUser(false);
    }
  };

  const signup = (email, password) => {
    if(email !== '' && password !== ''){
        setUser({id:1, name: email});
    }
  };

  const signout = () => {
    setUser(false);
  };

  const sendPasswordResetEmail = email => {
    return true;
  };

  const confirmPasswordReset = (code, password) => {
    return true;
  };
  
  // Return the user object and auth methods
  return {
    user,
    error,
    signin,
    ldapSignin,
    signup,
    signout,
    sendPasswordResetEmail,
    confirmPasswordReset
  };
}