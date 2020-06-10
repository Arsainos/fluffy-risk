import React from 'react';

// import functions and components if material UI
import AppBar from '@material-ui/core/AppBar';
import { makeStyles } from '@material-ui/core/styles';

// import project components
import SiteToolbar from '../UI/Toolbars/SiteToolbar';
import MobileToolbar from '../UI/Toolbars/MobileToolbar';

// style of component
const useStyles = makeStyles((theme) => ({
  appBar: {
    zIndex: 2000,
    [theme.breakpoints.down('xs')]: {
        top: 'auto',
        bottom: 0,
    }},
}));

export default function SearchAppBar({windowSize, ToogleDrawlerClick}) {
  const classes = useStyles();

  return (
    <AppBar position="fixed" className={classes.appBar}>
      {windowSize.width < 600 ? <MobileToolbar ToogleDrawlerClick={ToogleDrawlerClick} /> : <SiteToolbar ToogleDrawlerClick={ToogleDrawlerClick} />}                      
    </AppBar>
  );
}