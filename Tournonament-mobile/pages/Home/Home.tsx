import {FC} from "react"
import {url} from "../../constants"
import {HomeProps} from "./Home.types"
import {styles} from './Home.styles'
import {Button} from "react-native-paper"
import {View, Text, Image} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'

const Home: FC<HomeProps> = ({route}) => {
  const navigation = useNavigation<NavigationScreensType>()
  const {user} = route.params.response;
  console.log(user.imageUrl)
  console.log(url + user.imageUrl)
  const toAutorize = () => {
    navigation.navigate('Authorize');
  }
  return (
    <View>
      <Text style={styles.container}>Привет, {user.nickName}</Text>
      <Image style={{
        width: 400,
        height: 500
      }}
             source={{
               uri: url + user.imageUrl,
             }}></Image>
      <Button mode="contained" onPress={toAutorize}> На Авторизацию</Button>
    </View>
  )
}

export default Home