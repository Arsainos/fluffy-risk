import React, {useState} from 'react';

export default function useDrawer(drawerType) {
    const [isOpen, setState] = React.useState({
        bottom: false,
        left: false
    });
    
    const toggleDrawer = (anchor, open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }

        setState({ ...isOpen, [anchor]: open });
    };

    return {
        isOpen,
        toggleDrawer
    }
}