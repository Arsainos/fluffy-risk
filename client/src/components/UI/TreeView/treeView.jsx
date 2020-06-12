import React from 'react';

//import components and functions from material-ui
import { makeStyles } from '@material-ui/core/styles';
import TreeView from '@material-ui/lab/TreeView';
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import ArrowRightIcon from '@material-ui/icons/ArrowRight';

// import components
import StyledTreeItem from './TreeItem/treeItem';

// styles for components
const useStyles = makeStyles({
  root: {
    flexGrow: 1,
    maxWidth: '600px',
    boxSizing: 'initial'
  },
});

export default function RecursiveTreeView({TreeViewData}) {
    const classes = useStyles();
  
    const renderTreeItem = (nodes) => (
      <StyledTreeItem key={nodes.id} nodeId={nodes.id} labelText={nodes.name} labelIcon={nodes.labelIcon} color={nodes.color} bgColor={nodes.bgColor} to={nodes.to}>
          {Array.isArray(nodes.children) ? nodes.children.map((node) => renderTreeItem(node)) : null}
      </StyledTreeItem>
    );
  
    return (
      <TreeView
        className={classes.root}
        defaultCollapseIcon={<ArrowDropDownIcon />}
        defaultExpandIcon={<ArrowRightIcon />}
        defaultEndIcon={<div style={{ width: 24 }} />}
      >
        {TreeViewData.map((Tree) => renderTreeItem(Tree))}
      </TreeView>
    );
  }