
import React  from "react";
import { Home,Authorize } from "../pages";

import { NavigationContainer } from "@react-navigation/native";
import  {AppStack} from "./Stack"


export default function Navigate()
{
    return <NavigationContainer>
        <AppStack/>
    </NavigationContainer>
}