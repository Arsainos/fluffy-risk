import React, { Component} from 'react';

// import styles
import classes from './Layout.module.css';

// import components
import AppBar from '../AppBar/AppBar';

class Layout extends Component {
    render() {
        return (
            <React.Fragment>
                <AppBar/>
            </React.Fragment>
        )
    }
}

export default Layout;