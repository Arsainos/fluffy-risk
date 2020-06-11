import React from 'react';

//import components and functions from material-ui
import { makeStyles } from '@material-ui/core/styles';
import TreeView from '@material-ui/lab/TreeView';
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import ArrowRightIcon from '@material-ui/icons/ArrowRight';

// icon imports for tree items
import AssignmentIndIcon from '@material-ui/icons/AssignmentInd';
import NoteAddIcon from '@material-ui/icons/NoteAdd';
import PersonIcon from '@material-ui/icons/Person';
import SupervisorAccountIcon from '@material-ui/icons/SupervisorAccount';
import WorkIcon from '@material-ui/icons/Work';
import AccessibleIcon from '@material-ui/icons/Accessible';
import FitnessCenterIcon from '@material-ui/icons/FitnessCenter';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import PeopleIcon from '@material-ui/icons/People';
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import BeachAccessIcon from '@material-ui/icons/BeachAccess';

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

const data = [{
  id: 'ranks',
  name: 'Рейтингование',
  labelIcon: AssignmentIndIcon,
  children: [
    {
      id: 'createRank',
      name: 'Создать анкету',
      labelIcon: NoteAddIcon,
      color:"#1a73e8",
      bgColor:"#e8f0fe"
    },
    {
      id: 'myRanks',
      name: 'Мои анкеты',  
      labelIcon: PersonIcon,
      color:"#a250f5",
      bgColor:"#f3e8fd",
    },
    {
      id: 'ranksForGroups',
      name: 'Анкеты по подразделениям',
      labelIcon: SupervisorAccountIcon,
      color:"#3c8039",
      bgColor:"#e6f4ea",
    }
  ],
},
{
  id:'srp',
  name: 'СРП',
  labelIcon: WorkIcon,
  children: [
    {
      id: 'ClientMonitoring',
      name: 'Мониторинг клиентов',
      labelIcon: AccountBalanceIcon,
      color:"#1a73e8",
      bgColor:"#e8f0fe"
    },
    {
      id: 'signals',
      name: 'Сигналы по клиентам',
      labelIcon: BeachAccessIcon,
      color:"#a250f5",
      bgColor:"#f3e8fd",
    }
  ]
},
{
  id: 'clients',
  name: 'Клиенты',
  labelIcon: AccessibleIcon,
  children: [
    {
      id: 'newClient',
      name: 'Новый клиент',
      labelIcon: PersonAddIcon,
      color:"#1a73e8",
      bgColor:"#e8f0fe"
    },
    {
      id: 'allClients',
      name: 'Все клиенты',
      labelIcon: PeopleIcon,
      color:"#a250f5",
      bgColor:"#f3e8fd",
    }
  ]
},
{
  id: 'users',
  name: 'Пользователи',
  labelIcon: FitnessCenterIcon
}];

export default function RecursiveTreeView() {
    const classes = useStyles();
  
    const renderTreeItem = (nodes) => (
      <StyledTreeItem key={nodes.id} nodeId={nodes.id} labelText={nodes.name} labelIcon={nodes.labelIcon} color={nodes.color} bgColor={nodes.bgColor}>
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
        {data.map((Tree) => renderTreeItem(Tree))}
      </TreeView>
    );
  }