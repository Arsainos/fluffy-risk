import React, { useState } from 'react';

// import components and functions from material-ui
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import SwipeableDrawer from '@material-ui/core/SwipeableDrawer';
import List from '@material-ui/core/List';
import Divider from '@material-ui/core/Divider';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import MailIcon from '@material-ui/icons/Mail';

// import components

// component styles
const useStyles = makeStyles({
    list: {
        width: 250,
    },
    fullList: {
        width: 'auto',
    },
});

export default function Drawer({open, drawerType, onDrawerToogle, drawerClassName, drawerClasses, variantType}) {
    const classes = useStyles();

    const list = (anchor) => (
        <div
          className={clsx(classes.list, {
            [classes.fullList]: anchor === 'top' || anchor === 'bottom',
          })}
          role="presentation"
          onClick={onDrawerToogle(anchor, false)}
          onKeyDown={onDrawerToogle(anchor, false)}
        >
        <List>
            {['Inbox', 'Starred', 'Send email', 'Drafts'].map((text, index) => (
            <ListItem button key={text}>
                <ListItemIcon>{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                <ListItemText primary={text} />
            </ListItem>
            ))}
        </List>
        <Divider />
        <List>
            {['All mail', 'Trash', 'Spam'].map((text, index) => (
            <ListItem button key={text}>
                <ListItemIcon>{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                <ListItemText primary={text} />
            </ListItem>
            ))}
        </List>
        </div>
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
                {list(drawerType)}
        </SwipeableDrawer>
    );
}