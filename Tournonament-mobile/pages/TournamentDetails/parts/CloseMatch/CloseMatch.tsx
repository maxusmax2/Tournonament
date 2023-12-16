import { FC, useState } from "react";
import  {Button, Text, TextInput} from "react-native-paper"
import {CloseMatchProps, CloseMatchTypesFormType} from "./CloseMatch.types";
import { View } from "react-native";
import { QueryClient, QueryClientProvider } from "react-query";
import axios from "axios";
import { url } from "../../../../constants";


const CloseMatch: FC<CloseMatchProps> = ({match, visibleChange}) =>
{
  const  close = ()=>
  {
    var scoreList = [{"score":scoreOne,"playerId":match?.participants[0]?.id}
      ,{"score":scoreTwo,"playerId":match?.participants[1]?.id}]
    axios.put(
      `${url}/Tournament/CloseMatch`,
      {tournamentId: match.tournamentId, matchId: match.id, scoreList: scoreList
      }

    ).then(async (response) =>
    {
      visibleChange(false);

    })
      .catch(error=> console.log(error))
    axios.put(
      `${url}/Tournament/CloseGroups?tournamentId=${match.tournamentId}`,
      {tournamentId: match.tournamentId, matchId: match.id, scoreList: scoreList}
    ).catch(error=> console.log(error))
  }
  const  [scoreOne,setScoreOne] = useState("")
  const  [scoreTwo,setScoreTwo] = useState("")
  return(
    <View>
      <TextInput
        label={match?.participants[0]?.nickName}
        value={scoreOne}
        onChangeText={text => setScoreOne(text)}
        keyboardType={'numeric'}/>
      <TextInput
      label={match?.participants[1]?.nickName}
      value={scoreTwo}
      onChangeText={text => setScoreTwo(text)}
      keyboardType={'numeric'}/>
      <Button mode="contained" onPress={close}>Закрыть счет</Button>
    </View>
  )
}
export  default  CloseMatch;
