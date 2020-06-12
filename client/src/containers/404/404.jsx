import React from 'react';

// import fucntions and components of material-ui
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    svgIcons: {
        top: '50%',
        left: '50%',
    },
    messageBox: {
        top:'50%',
        left: '50%',
    },
    title: {
        marginBottom: '40px',
        lineHeight: '46px',
    },
    polygon1:{
        animation: '$puslating 2s infinite ease-in-out alternate, $round 6s infinite ease-in-out',      
    },
    polygon2: {
        animation: '$puslating 2.2s infinite ease-in-out alternate, $floatY 2s infinite ease-in-out alternate', 
    },
    polygon3: {
        animation: '$puslating 2.5s infinite ease-in-out alternate, $floatX 2s infinite ease-in-out alternate', 
    },
    polygon4: {
        animation: '$puslating 1.5s infinite ease-in-out alternate, $floatXY 3s infinite ease-in-out alternate', 
    },
    polygon5: {
        animation: '$puslating 3s infinite ease-in-out alternate, $floatXYandRoundBack 7s infinite ease-in-out alternate', 
    },
    '@keyframes puslating': {
        from: {opacity: 0.0},
        to: {opacity: 1}
    },
    '@keyframes floatY': {
        '100%': {
            transform: 'translateY(100px)'
        }
    },
    '@keyframes floatX': {
        '100%': {
            transform: 'translateX(-100px)'
        }
    },
    '@keyframes floatXY': {
        '100%': {
            transform: 'translateX(-100px) translateY(-150px)'
        }
    },
    '@keyframes round':{
        '0%': {
            transform: 'rotate(340deg)'
        },
        '50%':{
            transform: 'rotate(370deg)',
        },
        '100%': {
            transform: 'rotate(340deg)'
        }
    },
    '@keyframes floatXYandRoundBack':{
        '0%': {
            transform: 'rotate(360deg) translateX(100px) translateY(-50px)'
        },
        '50%':{
            transform: 'rotate(350deg)',
        },
        '100%': {
            transform: 'rotate(360deg) translateY(50px) translateX(-100px)'
        }
    }

}))

export default function PageNotFound() {
    const classes = useStyles();
    
    return (
        <React.Fragment>
            <svg className={classes.svgIcons} width="380px" height="500px" viewBox="0 0 837 1045" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns="http://www.w3.org/1999/xlink" xmlns="http://www.bohemiancoding.com/sketch/ns">
                <g id="Page-1" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                    <path className={classes.polygon1} d="M353,9 L626.664028,170 L626.664028,487 L353,642 L79.3359724,487 L79.3359724,170 L353,9 Z" stroke="#007FB2" stroke-width="6" type="MSShapeGroup" />
                    <path className={classes.polygon2} d="M78.5,529 L147,569.186414 L147,648.311216 L78.5,687 L10,648.311216 L10,569.186414 L78.5,529 Z" stroke="#EF4A5B" stroke-width="6" type="MSShapeGroup" />
                    <path className={classes.polygon3} d="M773,186 L827,217.538705 L827,279.636651 L773,310 L719,279.636651 L719,217.538705 L773,186 Z" stroke="#795D9C" stroke-width="6" type="MSShapeGroup" />
                    <path className={classes.polygon4} d="M639,529 L773,607.846761 L773,763.091627 L639,839 L505,763.091627 L505,607.846761 L639,529 Z" stroke="#F2773F" stroke-width="6" type="MSShapeGroup" />
                    <path className={classes.polygon5} d="M281,801 L383,861.025276 L383,979.21169 L281,1037 L179,979.21169 L179,861.025276 L281,801 Z" stroke="#36B455" stroke-width="6" type="MSShapeGroup" />
                </g>
            </svg>
            <div className={classes.messageBox}>
                <h1 className={classes.title}>404</h1>
                <p>Page not found</p>
            </div>
        </React.Fragment>
    )
}