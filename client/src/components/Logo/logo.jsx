import React from 'react';

// import components and functions from material-ui
import { makeStyles } from '@material-ui/core/styles';

// import images
import pawLogo from '../../assets/logo/material_feet.png';

// styles for component
const useStyles = makeStyles((theme) => ({
    logo: props => ({
        height: props.imageHeight,
        width: props.imageWidth,
        padding: theme.spacing(1, 1, 1, 0),
        [theme.breakpoints.down('sm')]: {
            height: props.isAppBarLogo ? '46px' : props.imageHeight
        }
    }),
    image: {
        height: '100%',
        width: 'auto'
    }
}));

export default function Logo(props) {
    const classes = useStyles(props);

    return (
        <div className={classes.logo}>
            <img className={classes.image} src={pawLogo} alt="Fluffy Risk Logo"/>
        </div>
    )
};