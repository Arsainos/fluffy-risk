import { useState } from "react";

export default function useAuthProvider() {
    const [user, setUser] = useState(null);
  
  // Wrap any web methods to signin user
  // just use admin/admin for testing
  const signin = (email, password) => {
    if(email === 'admin' && password === 'admin') {
        setUser({id:1, name:admin});
    } else {
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
    signin,
    signup,
    signout,
    sendPasswordResetEmail,
    confirmPasswordReset
  };
}