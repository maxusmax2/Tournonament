import { FC, useEffect, useState } from "react";
import {Group, GroupsListProps } from "./GroupsList.types";
import { url } from "../../../../constants";
import axios from "axios";
import { View } from "react-native";
import { MatchList } from "../MatchList";
import {Card, Text} from 'react-native-paper'

export const GroupsList: FC<GroupsListProps> = ({tornamentId})=>
{
  const [groups, setGroups] = useState<Array<Group>>();
  useEffect(() => {
    axios.get(
      `${url}/Tournament/GetTournamentsGroups/${tornamentId}`
    ).then(res => {
      console.log("groups", res.data.matchs)
      setGroups(res.data)
    })
  }, [setGroups]);

  return(
    <View>
      {groups?.map(({groupNumber, id, matchs, participants}) => (
      <View key={id}>

        <Text variant={"titleMedium"}>Группа №{groupNumber}</Text>
        {participants?.map(({nickName})=>(
          <Text>{nickName}</Text>
        ))}
        <MatchList matches={matchs}/>
      </View>
      ))}
    </View>
  )
}