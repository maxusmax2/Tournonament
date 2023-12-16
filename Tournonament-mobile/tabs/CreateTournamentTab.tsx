import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Home, Authorize, CreateTournament } from '../pages';
import { createMaterialBottomTabNavigator } from '@react-navigation/material-bottom-tabs';
import MaterialCommunityIcons from 'react-native-vector-icons/MaterialCommunityIcons';
import Profile from '../pages/Profile/Profile';

const Tab = createMaterialBottomTabNavigator();

// @ts-ignore
const HomeTab = ({route})=> {
    const { token, user } = route.params.response;
    return (
        <Tab.Navigator  barStyle={{ backgroundColor: '#343D4A' }}>
            <Tab.Screen
                options={{
                    tabBarLabel: 'Home',
                    tabBarIcon: ({ color }) => (
                        <MaterialCommunityIcons name="text-search" color={color}  size={26} />
                    ),}}
                name="Home"
                component={Home}
                initialParams={route.params} />
          <Tab.Screen
            options={{
              tabBarLabel: 'Create Tournament',
              tabBarIcon: ({ color }) => (
                <MaterialCommunityIcons name="tournament" color={color}  size={26} />
              ),}}
            name="CreateTournament"
            component={CreateTournament}
            initialParams={route.params} />
          <Tab.Screen
            options={{
              tabBarLabel: 'Profile',
              tabBarIcon: ({ color }) => (
                <MaterialCommunityIcons name="account-circle" color={color}  size={26} />
              ),}}
            name="Profile"
            component={Profile}
            initialParams={route.params} />
        </Tab.Navigator>
    );
}
export  default  HomeTab;