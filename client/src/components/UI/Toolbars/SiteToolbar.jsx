import React from 'react';

// import functions and components if material UI
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import InputBase from '@material-ui/core/InputBase';
import { fade, makeStyles } from '@material-ui/core/styles';
import MenuIcon from '@material-ui/icons/Menu';
import SearchIcon from '@material-ui/icons/Search';

// import project components
import Logo from '../Logo/logo';

// style of component
const useStyles = makeStyles((theme) => ({
    menuButton: {
      marginRight: theme.spacing(2),
      [theme.breakpoints.up('xl')]: {
          display: 'none'
      },
      [theme.breakpoints.down('xs')]: {
          display: 'none'
      }
    },
    title: {
      flexGrow: 1,
      display: 'none',
      [theme.breakpoints.up('sm')]: {
          display: 'block',
      },
    },
    search: {
      position: 'relative',
      borderRadius: theme.shape.borderRadius,
      backgroundColor: fade(theme.palette.common.white, 0.15),
      '&:hover': {
          backgroundColor: fade(theme.palette.common.white, 0.25),
      },
      marginLeft: 0,
      width: '100%',
      [theme.breakpoints.up('sm')]: {
          marginLeft: theme.spacing(1),
          width: 'auto',
      },
      [theme.breakpoints.down('xs')]: {
          display: 'none'
      }
    },
    searchIcon: {
      padding: theme.spacing(0, 2),
      height: '100%',
      position: 'absolute',
      pointerEvents: 'none',
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
    },
    inputRoot: {
      color: 'inherit',
    },
    inputInput: {
      padding: theme.spacing(1, 1, 1, 0),
      // vertical padding + font size from searchIcon
      paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
      transition: theme.transitions.create('width'),
      width: '100%',
      [theme.breakpoints.up('sm')]: {
          width: '12ch',
          '&:focus': {
              width: '20ch',
          },
      },
      [theme.breakpoints.up('md')]: {
          width: '20ch',
          '&:focus': {
              width: '30ch',
          },
      },
      [theme.breakpoints.up('lg')]: {
          width: '30ch',
          '&:focus': {
              width: '40ch',
          },
      },
      [theme.breakpoints.up('xl')]: {
          width: '40ch',
          '&:focus': {
              width: '50ch',
          },
      }
    },
    siteToolbar: {
        [theme.breakpoints.down('xs')]: {
            display: 'none'
        }
    }
}));

export default function SiteToolbar() {
    const classes = useStyles();
    
    return (
        <Toolbar className={classes.siteToolbar}>
            <IconButton
                edge="start"
                className={classes.menuButton}
                color="inherit"
                aria-label="open drawer"
            >
            <MenuIcon />
            </IconButton>
            
            <Logo imageHeight="56px" imageWidth="auto" isAppBarLogo/>

            <Typography className={classes.title} variant="h6" noWrap>
                Fluffy Risk
            </Typography>

            <div className={classes.search}>
                <div className={classes.searchIcon}>
                    <SearchIcon />
                </div>
                <InputBase
                    placeholder="Поиск…"
                    classes={{
                        root: classes.inputRoot,
                        input: classes.inputInput,
                    }}
                    inputProps={{ 'aria-label': 'search' }}
                />
            </div>
        </Toolbar>
    )
}