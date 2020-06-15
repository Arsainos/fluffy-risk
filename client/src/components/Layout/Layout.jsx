import React from 'react';

// import fucntions and components of material-ui
import { makeStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';

// import components
import AppBar from '../AppBar/AppBar';
import Drawer from '../UI/Drawer/drawer';
import TreeViewDrawer from '../UI/TreeView/treeView';

// import custom hooks
import useDrawer from '../../Hooks/useDrawer/useDrawer';
import useWindowSize from '../../Hooks/useWindowSize/useWindowSize';

// import data
import { TreeViewData } from '../../Routes/routeLinks';

// style of component
const useStyles = makeStyles((theme, size) => ({
    root: {
      display: 'flex',
    },
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
    },
    drawer: size => ({
        width: size.width > Mobile ? '300px' : 'auto',
        flexShrink: 0, 
    }),
      drawerPaper: size => ({
        width: size.width > Mobile ? '300px' : 'auto',
        marginBottom: size.width <= Mobile ? '56px' : '0',
        marginTop: size.width > Mobile ? '64px' : '0',
        paddingTop: size.width > Mobile ? '18px' : '9px',
        top: size.width > Mobile ? 'auto' : '30%',
        height: '100%'
    }),
    content: size => ({
        position: 'relative',
        flexGrow: 1,
        padding: size.width > Mobile ? theme.spacing(9,3,3,3) : theme.spacing(3)
    }),
}));

// constants
const MobileToolbarDrawerType = 'bottom';
const SiteToolbarDrawerType = 'left';
const FullHD = 1080;
const Mobile = 600;

export default function Layout(props) {
    const {isOpen, toggleDrawer} = useDrawer(SiteToolbarDrawerType);
    const size = useWindowSize();
    const drawerType = size.width <= Mobile ? MobileToolbarDrawerType : SiteToolbarDrawerType;
    const classes = useStyles(size);
    
    return (
        <div className={classes.root}>
            <CssBaseline />
            <AppBar
                windowSize={size} 
                ToogleDrawlerClick={() => toggleDrawer(drawerType, !isOpen[drawerType])} 
                outerClasses={classes.appBar}
            />
            <Drawer 
                drawerType={drawerType} 
                open={size.width >= FullHD ? true : isOpen[drawerType]} 
                onDrawerToogle={toggleDrawer}
                variantType={size.width >= FullHD ? 'permanent' : null}
                drawerClassName={classes.drawer}
                drawerClasses={{paper: classes.drawerPaper}}
                drawerContent={<TreeViewDrawer TreeViewData={TreeViewData} />}
            />
            <main className={classes.content}>
                {props.children}
            </main>
        </div>
    )
};