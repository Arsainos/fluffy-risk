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

// import components
import Drawer from '../Drawer/drawer';

// import custom hooks
import useDrawer from '../../../Hooks/useDrawer/useDrawer';

// style of component
const useStyles = makeStyles((theme) => ({
  homeIcon: {
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  notificationIcon: {
    padding: theme.spacing(0, 6, 0, 0),
    textAlign: 'left',
    [theme.breakpoints.up('sm')]: {
        display: 'none',
    },
  },
  messagesIcon: {
    padding: theme.spacing(0, 0, 0, 6),
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

const MobileToolbarDrawerType = 'bottom';

export default function MobileToolbar() {
    const classes = useStyles();
    const {isOpen, toggleDrawer} = useDrawer(MobileToolbarDrawerType);

    return (
      <Toolbar className={classes.mobileToolbar}>
        <div className={classes.ribbonPanel} >
          <Fab color="secondary" aria-label="open-menu" className={classes.fabButton} size="large" onClick={toggleDrawer(MobileToolbarDrawerType, true)}>
            <PetsIcon />
          </Fab>
          <HomeIcon className={classes.homeIcon} />
          <NotificationIcon className={classes.notificationIcon} />
          <MessagesIcon className={classes.messagesIcon} />
          <SearchIcon className={classes.searchIcon} />            
        </div>
        <Drawer drawerType={MobileToolbarDrawerType} open={isOpen[MobileToolbarDrawerType]} onDrawerToogle={toggleDrawer}/>
      </Toolbar>      
    )
}