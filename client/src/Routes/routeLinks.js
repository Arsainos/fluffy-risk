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
import HomeIcon from '@material-ui/icons/Home';
import FaceIcon from '@material-ui/icons/Face';
import GroupWorkIcon from '@material-ui/icons/GroupWork';
import PeopleOutlineIcon from '@material-ui/icons/PeopleOutline';

export const TreeViewData = [
    {
    id: 'mainPage',
    name: 'Главная страница',
    labelIcon: HomeIcon,
    to:'/Home'
    },
    {
    id: 'ranks',
    name: 'Рейтингование',
    labelIcon: AssignmentIndIcon,
    to:'/ranks',
    children: [
      {
        id: 'createRank',
        name: 'Создать анкету',
        labelIcon: NoteAddIcon,
        color:"#1a73e8",
        bgColor:"#e8f0fe",
        to:'/ranks/createRank'
      },
      {
        id: 'myRanks',
        name: 'Мои анкеты',  
        labelIcon: PersonIcon,
        color:"#a250f5",
        bgColor:"#f3e8fd",
        to:'/ranks/myRanks'
      },
      {
        id: 'ranksForGroups',
        name: 'Анкеты по подразделениям',
        labelIcon: SupervisorAccountIcon,
        color:"#3c8039",
        bgColor:"#e6f4ea",
        to:'/ranks/groupRanks'
      }
    ],
  },
  {
    id:'srp',
    name: 'СРП',
    to:'/Srp',
    labelIcon: WorkIcon,
    children: [
      {
        id: 'ClientMonitoring',
        name: 'Мониторинг клиентов',
        labelIcon: AccountBalanceIcon,
        color:"#1a73e8",
        bgColor:"#e8f0fe",
        to:'/Srp/clientMonitoring',
      },
      {
        id: 'signals',
        name: 'Сигналы по клиентам',
        labelIcon: BeachAccessIcon,
        color:"#a250f5",
        bgColor:"#f3e8fd",
        to:'/Srp/clientsSignals',
      }
    ]
  },
  {
    id: 'clients',
    name: 'Клиенты',
    to:'/Clients',
    labelIcon: AccessibleIcon,
    children: [
      {
        id: 'newClient',
        name: 'Новый клиент',
        labelIcon: PersonAddIcon,
        color:"#1a73e8",
        bgColor:"#e8f0fe",
        to:'/Clients/newClient',
      },
      {
        id: 'allClients',
        name: 'Все клиенты',
        labelIcon: PeopleIcon,
        color:"#a250f5",
        bgColor:"#f3e8fd",
        to:'/Clients/allClients',
      },
    ]
  },
  {
    id: 'users',
    name: 'Пользователи',
    labelIcon: FitnessCenterIcon,
    to:'/Users',
    children: [
        {
            id: 'myProfile',
            name: 'Мой профиль',
            labelIcon: FaceIcon,           
            color:"#a250f5",
            bgColor:"#f3e8fd",
            to: '/Users/account',
        },
        {
            id: 'myGroup',
            name: 'Группы пользователей',
            labelIcon: GroupWorkIcon,
            color:"#3c8039",
            bgColor:"#e6f4ea",
            to: '/Users/usersByGroup',
        },
        {
            id: 'allUsers',
            name: 'Все пользователи',
            labelIcon: PeopleOutlineIcon,
            color:"#1a73e8",
            bgColor:"#e8f0fe",
            to:'/Users/allUsers',
        }
    ]
  }];