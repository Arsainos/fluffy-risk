import React from 'react';

// import functions and components if material UI
import Toolbar from '@material-ui/core/Toolbar';
import { makeStyles } from '@material-ui/core/styles';
import Fab from '@material-ui/core/Fab';
import SearchIcon from '@material-ui/icons/Search';
import HomeIcon from '@material-ui/icons/Home';
import NotificationIcon from '@material-ui/icons/Notifications';
import MessagesIcon from '@material-ui/icons/Message';
import PetsIcon from '@material-ui/icons/Pets';

// style of component
const useStyles = makeStyles((theme) => ({
  homeIcon: {
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  notificationIcon: {
    marginRight: '3ch',
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  messagesIcon: {
    marginLeft: '3ch',
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  searchIcon: {
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  ribbonPanel: {
    padding: theme.spacing(1, 4, 1, 4),
    lineHeight: '0',
    width: '100%',
    display: 'flex',
    justifyContent: 'space-between',
    [theme.breakpoints.up('sm')]: {
        display: 'none'
    }
  },
  fabButton: {
    position: 'absolute',
    zIndex: 1,
    top: -30,
    left: 0,
    right: 0,
    margin: '0 auto',
  },
  mobileToolbar: {
    [theme.breakpoints.up('sm')]: {
      display: 'none'
    }
  }
}));

export default function MobileToolbar({ToogleDrawlerClick}) {
    const classes = useStyles();

    return (
      <Toolbar className={classes.mobileToolbar}>
        <div className={classes.ribbonPanel} >
          <Fab color="secondary" aria-label="open-menu" className={classes.fabButton} size="large" onClick={ToogleDrawlerClick()}>
            <PetsIcon />
          </Fab>
          <HomeIcon className={classes.homeIcon} />
          <NotificationIcon className={classes.notificationIcon} />
          <MessagesIcon className={classes.messagesIcon} />
          <SearchIcon className={classes.searchIcon} />            
        </div>
      </Toolbar>      
    )
}