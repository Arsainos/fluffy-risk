import React from 'react';

// import functions and components if material UI
import AppBar from '@material-ui/core/AppBar';
import { makeStyles } from '@material-ui/core/styles';

// import project components
import SiteToolbar from '../UI/Toolbars/SiteToolbar';
import MobileToolbar from '../UI/Toolbars/MobileToolbar';

// style of component
const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  appBar: {
    [theme.breakpoints.down('xs')]: {
        top: 'auto',
        bottom: 0,
    }
  },
}));

export default function SearchAppBar() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
        <AppBar position="fixed" className={classes.appBar}>
            <SiteToolbar />
            <MobileToolbar />
        </AppBar>
    </div>
  );
}