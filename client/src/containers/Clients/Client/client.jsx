import React, {useState} from 'react';

// import components and functions from naterial-ui
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

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

export default function Client({type}) {
  const [TextFieldsInputs, setTextFieldInputs] = useState({
    clientName: '',
    clientInn: '',
    clientHolding: '',
  });

  const classes = useStyles();

  const handleTextInputChange = (event) => {
    setTextFieldInputs({...TextFieldsInputs, [event.target.name]: event.target.value});
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          {type === 'show' || type === 'edit' ? 'Клиент №1' : 'Создание нового клиента'}
        </Typography>
        <form className={classes.form} noValidate>
            <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                id="clientName"
                label="Имя клиента"
                name="clientName"
                autoComplete="clientName"
                autoFocus
                value={TextFieldsInputs.clientName}
                onChange={handleTextInputChange}
                disabled={type === 'show'}
            />
            <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                id="clientInn"
                label="ИНН"
                name="clientInn"
                autoComplete="clientInn"
                value={TextFieldsInputs.clientInn}
                onChange={handleTextInputChange}
                disabled={type === 'show'}
            />
            <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                name="clientHolding"
                label="Группа"
                id="clientHolding"
                autoComplete="clientHolding"
                value={TextFieldsInputs.clientHolding}
                onChange={handleTextInputChange}
                disabled={type === 'show'}
            />
            <Button
                fullWidth
                variant="contained"
                color="primary"
                className={classes.submit}  
                disabled={type === 'show'}              
            >
                {type === 'show' || type === 'edit' ? 'Сохранить изменения по клиенту' : 'Создать клиента'}                
            </Button>        
        </form>
      </div>
    </Container>
  );
}