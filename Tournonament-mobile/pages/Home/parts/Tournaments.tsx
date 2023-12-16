import {Button, Card,Text} from "react-native-paper"
import { TournamentCard } from "../Home.styles"
import { useNavigation } from "@react-navigation/native"
import { NavigationScreensType } from "../../../navigate/Navigate.type"
import { FC } from "react"
import { TournamentsProps } from "./Tournaments.types"
import { View } from "react-native"


const Tournaments: FC<TournamentsProps> = ({tournaments})=>
{
  const navigation = useNavigation < NavigationScreensType > ()
  const formateDate = (date: string)=> {
    return new Date(date).toLocaleDateString('ru')
  }
  const toDetails = (id:number)=>
  {
    navigation.navigate('TournamentDetails', {response: id});
  }
  return(
    <View>
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
        </TournamentCard>)}
    </View>

)}
export  default  Tournaments;