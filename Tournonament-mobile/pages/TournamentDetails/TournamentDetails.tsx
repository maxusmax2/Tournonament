import {FC, useEffect, useState} from "react"
import {url} from "../../constants"

import {Button, Card, Text} from "react-native-paper"
import {ScrollView, View} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import useToken from "../../ui/hooks/useToken"
import axios from "axios"
import { styles } from "./TournamentDetails.styles"

//@ts-ignore
const TournamentDetails: FC = ({route}) => {
  const [tournament,setTournament] = useState<any>();
  const token = useToken()
  const navigation = useNavigation < NavigationScreensType > ()

  useEffect(() => {
    axios.get(
      `${url}/Tournament?tournamentId=${route.params.response}`
    ).then(res => {
      console.log("tournament",res.data.name)
      setTournament(res.data)
    })
  }, [setTournament]);

  const toAutorize = () => {
    navigation.navigate('Authorize');
  }

  return(
    <View style={styles.container}>
      <Text variant="bodyMedium">{tournament?.name}</Text>
      
    </View>
    )
}

export default TournamentDetails