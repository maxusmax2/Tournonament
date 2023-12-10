import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Home, Authorize } from '../pages';
import { createMaterialBottomTabNavigator } from '@react-navigation/material-bottom-tabs';
import MaterialCommunityIcons from 'react-native-vector-icons/MaterialCommunityIcons';
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
                        <MaterialCommunityIcons name="home" color={color}  size={26} />
                    ),}}
                name="Home"
                component={Home}
                initialParams={route.params} />
        </Tab.Navigator>
    );
}
export  default  HomeTab;