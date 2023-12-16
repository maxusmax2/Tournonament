import { FC, useEffect, useState } from "react";
import { ScrollView, View } from "react-native";
import {Text} from "react-native-paper"
import * as SecureStore from 'expo-secure-store';
import { userInfo } from "./Profile.types";
import ToggleSwitch from "toggle-switch-react-native";
import { styles } from "./Profile.styles";
import { MatchList } from "../TournamentDetails/parts/MatchList";
import { Match } from "../TournamentDetails/parts/Match/Match.types";
import axios from "axios";
import { url } from "../../constants";
import Tournaments from "../Home/parts/Tournaments";
const Profile:FC = ()=>
{
  const [matchies,setMatchies] = useState<Array<Match>>([])
  const [tournaments,setTournaments] = useState<Array<any>>([])
  const [user,setUser] = useState<userInfo>()
  const [matchTournamentSwitch,setMatchTournamentSwitch] = useState(false)
  SecureStore.getItemAsync("user").then(res => setUser(JSON.parse(res ?? "")))

  useEffect(() => {

    axios.get(
      `${url}/User/GetTournament/${user?.id}`
    ).then(res => {
      setTournaments(res.data)
    })
    axios.get(
      `${url}/User/GetMatchies/${user?.id}`
    ).then(res => {
      setMatchies(res.data)
    })

  }, [setTournaments,setMatchies]);
  return(
    <ScrollView style={styles.container}>
      <Text variant="bodyLarge">{user?.nickName}</Text>
      <Text variant="bodyLarge">{user?.birthday}</Text>
      <Text variant="bodyLarge">{user?.aboutMe}</Text>
      <ToggleSwitch
        isOn={matchTournamentSwitch}
        onColor="blue"
        offColor="green"
        label="Группа/playoff"
        labelStyle={{color: "white", fontWeight: "900"}}
        size="large"
        onToggle={setMatchTournamentSwitch}
      />
      {matchTournamentSwitch == false && <View>
        <Text variant="bodyLarge"> Твои Матчи</Text>
        <MatchList matches={matchies}/></View>}
      {matchTournamentSwitch && <View>
        <Text variant="bodyLarge"> Твои Турниры</Text>
        <Tournaments tournaments={tournaments}/></View>}

    </ScrollView>
  )
}
export  default  Profile