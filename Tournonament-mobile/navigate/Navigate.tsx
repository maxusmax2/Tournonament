import React  from "react";
import { Home,Authorize } from "../pages";

import {createStackNavigator} from '@react-navigation/stack'
import { NavigationContainer } from "@react-navigation/native";
import { StackScreenList } from "./Navigate.type";

const Stack = createStackNavigator<StackScreenList>()

export default function Navigate()
{
    return <NavigationContainer>
        <Stack.Navigator>
            <Stack.Screen
            name="Home"
            component={Home}
            options={{title: 'Главная страница'}} />

            <Stack.Screen
            name="Authorize"
            component={Authorize}
            options={{title: 'Авторизация'}}/>
        </Stack.Navigator>
    </NavigationContainer>
}