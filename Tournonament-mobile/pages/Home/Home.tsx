import {FC, useEffect, useState} from "react"
import {url} from "../../constants"
import {HomeProps} from "./Home.types"
import {styles, TournamentCard} from './Home.styles'
import {Button, Card, Text, TextInput} from "react-native-paper"
import {ScrollView, View} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import useToken from "../../ui/hooks/useToken"
import axios from "axios"
import Tournaments from "./parts/Tournaments"


const Home: FC<HomeProps> = ({route}) => {
  const [searchString,setSearchString] = useState("")
  const [tournaments, setTournaments] = useState([]);
  const token = useToken()
  const navigation = useNavigation < NavigationScreensType > ()
  useEffect(() => {
    axios.get(
      `${url}/Tournament/GetAll?pageNumber=0&pageGize=25`
    ).then(res => setTournaments(res.data))

  }, [setTournaments]);

  const toAutorize = () => {
    navigation.navigate('Authorize');
  }
  //@ts-ignore
  const formateDate = (date)=> {
    return new Date(date).toLocaleDateString('ru')
  }
  const  search = ()=>
  {
    axios.get(
      `${url}/Tournament/Search?name=${searchString}&pageNumber=0&pageGize=25`
    ).then(res => setTournaments(res.data))

  }

  const toDetails = (id:number)=>
  {
    navigation.navigate('TournamentDetails', {response: id});
  }
  return(
    <ScrollView style={styles.container}>
      <TextInput
        label={"Поиск"}
        value={searchString}
        onChangeText={text => setSearchString(text)}/>
      <Button mode="contained" onPress={search}>Поиск</Button>
      <Text variant="titleLarge">Турниры</Text>
      <Tournaments tournaments={tournaments}/>
    </ScrollView>
  )
}

export default Home