import { FC } from "react"

import { HomeProps } from "./Home.types"
import { styles } from './Home.styles'
import { Button } from "react-native-paper"
import { View, Text  } from "react-native"
import { useNavigation } from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'

const Home:FC<HomeProps> = ({name="Мася"}) => {
    const navigation = useNavigation<NavigationScreensType>()
    const toAutorize = ()=>
    {
        navigation.navigate('Authorize');
    }
    return(
        <View>
            <Text style={styles.container}>Привет, {name}</Text>
            <Button mode="contained" onPress={toAutorize}> На Афквторизацию</Button>
        </View>
    )
}

export default Home