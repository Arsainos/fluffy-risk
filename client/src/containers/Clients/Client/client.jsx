import React, {useState} from 'react';

// import components and functions from naterial-ui
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

// import custom hooks
import useRouter from '../../../Hooks/useRouter/useRouter';
import useClientRequire from '../../../Hooks/useClientRequire/useClientRequire';
import { useEffect } from 'react';

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
  const {client} = useClientRequire();
  const router = useRouter();

  if(!type) { 
    if(router.query.action) {
      type = router.query.action; 
    } else {
      type = 'show';
    }
  }

  const [TextFieldsInputs, setTextFieldInputs] = useState({
    clientName: '', //client ? client.clientName : '' ,
    clientInn: '', //client ? client.clientInn : '' ,
    clientHolding: '', //client ? client.clientHolding : '' ,
  });

  useEffect(() => {
    if(client.client) {
      const clientData = client.client;
      setTextFieldInputs({clientName: clientData.clientName, clientInn: clientData.clientInn, clientHolding: clientData.clientHolding})
    } else {
      setTextFieldInputs({clientName: '', clientInn: '', clientHolding: ''})
    }
  }, [client.client]);

  const classes = useStyles();

  const handleTextInputChange = (event) => {
    setTextFieldInputs({...TextFieldsInputs, [event.target.name]: event.target.value});
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          {type === 'show' || type === 'edit' ? `${TextFieldsInputs.clientName}` : 'Создание нового клиента'}
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
                onClick={() => {
                  if(type === 'show' || type === 'edit' ) {
                    client.editClient({
                      id: client.client.id,
                      ...TextFieldsInputs                 
                    });
                    router.push('/Clients/AllClients');
                  } else {
                    client.createClient({
                      ...TextFieldsInputs
                    });
                    router.push('/Clients/AllClients');
                  }
                }}          
            >
                {type === 'show' || type === 'edit' ? 'Сохранить изменения по клиенту' : 'Создать клиента'}                
            </Button>        
        </form>
      </div>
    </Container>
  );
}