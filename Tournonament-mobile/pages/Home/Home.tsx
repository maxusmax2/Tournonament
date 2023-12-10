import {FC, useEffect, useState} from "react"
import {url} from "../../constants"
import {HomeProps} from "./Home.types"
import {styles, TournamentCard} from './Home.styles'
import {Button, Card, Text} from "react-native-paper"
import {ScrollView, View} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import useToken from "../../ui/hooks/useToken"
import axios from "axios"


const Home: FC<HomeProps> = ({route}) => {
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

  const toDetails = (id:number)=>
  {
    navigation.navigate('TournamentDetails', {response: id});
  }
  return(
    <ScrollView style={styles.container}>
      <Text variant="titleLarge">Турниры</Text>
      {tournaments?.map(({name, description, participantNumber, participantNumberMax, date, id}) =>
        <TournamentCard key={id}>
          <Card.Title title={name}/>
          <Card.Content>
            <Text variant="bodyMedium">{description}</Text>
          </Card.Content>
          <Card.Actions>
            <Text variant="bodyMedium">{participantNumber}/{participantNumberMax}</Text>
            <Text variant="bodyMedium">{formateDate(date)}</Text>
            <Button mode="contained" onPress={()=>toDetails(id)}>Вступить</Button>
          </Card.Actions>
        </TournamentCard>)
      }
    </ScrollView>
  )
}

export default Home