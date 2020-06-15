import React from 'react';

// import components and functions from material-ui
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import SwipeableDrawer from '@material-ui/core/SwipeableDrawer';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';

// component styles
const useStyles = makeStyles({
    list: {
        width: 300,
    },
    fullList: {
        width: 'auto',
    },
});

export default function Drawer({open, drawerType, onDrawerToogle, drawerClassName, drawerClasses, variantType, drawerContent}) {
    const classes = useStyles();  

    const list = (anchor, content) => (
        <ClickAwayListener onClickAway={onDrawerToogle(anchor, false)}>
            <div
            className={clsx(classes.list, {
                [classes.fullList]: anchor === 'top' || anchor === 'bottom',
            })}
            role="presentation"
            >
                {content}
            </div>
        </ClickAwayListener>
    );

    return (
        <SwipeableDrawer 
            className={drawerClassName}
            classes={drawerClasses}
            anchor={drawerType} 
            open={open} 
            variant={variantType}
            onClose={onDrawerToogle(drawerType, false)}
            onOpen={onDrawerToogle(drawerType, true)}
        >
            {list(drawerType, drawerContent)}
        </SwipeableDrawer>
    );
}