import {FC, useEffect, useState} from "react"
import {url} from "../../constants"
import ToggleSwitch from 'toggle-switch-react-native'
import {Button, Card, Text} from "react-native-paper"
import {ScrollView, View} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import useToken from "../../ui/hooks/useToken"
import axios from "axios"
import {styles} from "./TournamentDetails.styles"
import {BracketMatchList} from "./parts"
import { GroupsList } from "./parts/GroupsList/GroupsList"
import * as SecureStore from 'expo-secure-store';
import { Tournament } from "./tournamentDetails.types"
//@ts-ignore
const TournamentDetails: FC = ({route}) => {
  const [tournament, setTournament] = useState<Tournament>();
  const [user,setUser] = useState<any>()
  const token = useToken()
  const navigation = useNavigation<NavigationScreensType>()
  const [groupPlayOffSwitch, setGroupPlayOffSwitch] = useState(true);
  const tournamentId = route.params.response;
  const [rendered, setRendered] = useState(false)
  const onGroupPlayOffSwitch = () => setGroupPlayOffSwitch(!groupPlayOffSwitch)

  useEffect(() => {

    SecureStore.getItemAsync("user").then(res => setUser(JSON.parse(res ?? "")))
    axios.get(
      `${url}/Tournament?tournamentId=${tournamentId}`
    ).then(res => {
      setTournament(res.data)
    })
    setGroupPlayOffSwitch((tournament?.withGroupStep == false) )
    setRendered(true)
  }, [setTournament]);
  const formateDate = (date: string) => {
    return new Date(date).toLocaleDateString('ru')
  }
  const closeRecruitment = (tournamentId:number) =>
  {
    axios.put(
      `${url}/Tournament/CloseRecruitment?tournamentId=${tournamentId}`
    ).then(res => {
      setTournament(res.data)
    })
  }
  const decline = (tournamentId:number) =>
  {
    axios.put(
      `${url}/Tournament/DeclineTournament?tournamentId${tournamentId}`
    ).then(res => {
      setTournament(res.data)
    })
  }
  const addParticipant = (tournamentId:number)=>
  {
    axios.put(
      `${url}/Tournament/AddParticipant?playerId=${user?.id}&tournamentId=${tournamentId}`
    ).then(res => {
      setTournament(res.data)
    })
  }
  const removeParticipant = (tournamentId:number)=>
  {
    axios.put(
      `${url}/Tournament/RemoveParticipant?playerId=${user?.id}&touramentId=${tournamentId}`
    ).then(res => {
      setTournament(res.data)
    })
  }
  const isParticipants = () : boolean =>
  {
    let result = false
    tournament?.participants?.forEach((player)=>
    {
      if(player?.id == user?.id) result = true;
    });
    return result;
  }

  return (
    <View style={styles.container} key={tournamentId}>
      <Text variant="bodyLarge">{tournament?.name}</Text>
      <Text variant="bodyMedium">{tournament?.participantNumber}/{tournament?.participantNumberMax}</Text>
      <Text variant="bodyMedium">{formateDate(tournament?.date ?? "")}</Text>
      <Text variant="bodyMedium">{tournament?.description}</Text>
      {tournament?.participants?.map(({nickName})=>(
        <Text variant="bodyMedium" style={{color:"white"}}>{nickName}</Text>
      ))}

      {tournament?.status == 0 &&  tournament?.creatorId == user?.id &&
        <Button mode="contained" onPress={()=>closeRecruitment(tournamentId)}>Закрыть набор</Button>}

      {tournament?.status != 1 && tournament?.creatorId == user?.id &&
        <Button mode="contained" onPress={()=>decline(tournamentId)}>Отменить</Button>}

      {isParticipants() == false && tournament?.status == 0 &&
        <Button mode="contained" onPress={()=>addParticipant(tournamentId)}>Вступить</Button>}
      {isParticipants() && tournament?.status == 0 &&
        <Button mode="contained" onPress={()=>removeParticipant(tournamentId)}>Выйти</Button>}

      {tournament?.withGroupStep && tournament?.status != 3 &&
        <ToggleSwitch
          isOn={groupPlayOffSwitch}
          onColor="blue"
          offColor="green"
          label="Группа/playoff"
          labelStyle={{color: "white", fontWeight: "900"}}
          size="large"
          onToggle={onGroupPlayOffSwitch}
        />
      }
      {groupPlayOffSwitch && <BracketMatchList tornamentId={tournamentId}/>}
      {groupPlayOffSwitch == false && <GroupsList tornamentId={tournamentId}/>}

    </View>
  )
}
export default TournamentDetails