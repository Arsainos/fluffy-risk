import React from 'react';

// import components and functions from naterial-ui
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';

// import hooks
import useAuth from '../../Hooks/useAuth/useAuth';
import { useState } from 'react';

// component styles
const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  errorText: {
    color: 'red',
  }
}));

export default function SignIn() {
  const [state,setState] = useState({ldapToogle:false});
  const [TextFieldsInputs, setTextFieldInputs] = useState({
    ldapName: '',
    ldapUser: '',
    ldapPassword: '',
    user: '',
    password: ''
  });

  const classes = useStyles();
  const auth = useAuth();

  const handleToogle = (event) => {
    setState({...state, [event.target.name]: event.target.checked})
  }

  const handleTextInputChange = (event) => {
    setTextFieldInputs({...TextFieldsInputs, [event.target.name]: event.target.value});
  }

  const formContent = state.ldapToogle ? (
    <React.Fragment>
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        id="ldapName"
        label="Имя сервера AD"
        name="ldapName"
        autoComplete="ldapName"
        autoFocus
        value={TextFieldsInputs.ldapName}
        onChange={handleTextInputChange}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        id="ldapUser"
        label="Имя пользователя в AD"
        name="ldapUser"
        autoComplete="ldapUser"
        value={TextFieldsInputs.ldapUser}
        onChange={handleTextInputChange}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        name="ldapPassword"
        label="Пароль из AD"
        type="password"
        id="lpadPassword"
        autoComplete="ldapPassword"
        value={TextFieldsInputs.ldapPassword}
        onChange={handleTextInputChange}
      />
      <Button
        fullWidth
        variant="contained"
        color="primary"
        className={classes.submit}
        onClick={() => auth.ldapSignin(TextFieldsInputs.ldapName, TextFieldsInputs.ldapUser, TextFieldsInputs.ldapPassword)}
      >
        Войти через AD
      </Button>
      <Grid container>
        <Grid item xs>
          <Link href="#" variant="body2">
            Забыли пароль от AD?
          </Link>
        </Grid>
        <Grid item>
          <Link href="#" variant="body2">
            {"Don't have an account? Sign Up"}
          </Link>
        </Grid>
      </Grid>
    </React.Fragment>
  ) : (
    <React.Fragment>
    <TextField
      variant="outlined"
      margin="normal"
      required
      fullWidth
      id="user"
      label="Имя пользователя"
      name="user"
      autoComplete="user"
      value={TextFieldsInputs.user}
      onChange={handleTextInputChange}
    />
    <TextField
      variant="outlined"
      margin="normal"
      required
      fullWidth
      name="password"
      label="Пароль"
      type="password"
      id="password"
      autoComplete="password"
      value={TextFieldsInputs.password}
      onChange={handleTextInputChange}
    />
    <Button
      fullWidth
      variant="contained"
      color="primary"
      className={classes.submit}
      onClick={() => auth.signin(TextFieldsInputs.user, TextFieldsInputs.password)}
    >
      Войти
    </Button>
    <Grid container>
      <Grid item xs>
        <Link href="#" variant="body2">
          Забыли пароль?
        </Link>
      </Grid>
      <Grid item>
        <Link href="#" variant="body2">
          {"Нет аккаунта? Зарегестрируйтесь"}
        </Link>
      </Grid>
    </Grid>
  </React.Fragment>
  )

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Авторизация
        </Typography>
        <form className={classes.form} noValidate>
          {auth.error ? 
            <Grid container>
              <Grid item xs>
                <p className={classes.errorText}>
                  {auth.error}
                </p>
              </Grid>
            </Grid>
           : null}
          <FormControlLabel
            control={<Switch checked={state.ldapToogle} onChange={handleToogle} name="ldapToogle" />}
            label="Вход через LDAP"
          />
          {formContent}         
        </form>
      </div>
    </Container>
  );
}