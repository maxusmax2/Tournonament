import {FC, useEffect, useState} from 'react'
import {Card, Text} from 'react-native-paper'
import {BracketMatchListProps} from './BracketMatchList.types'
import {View} from 'react-native'
import axios from 'axios'
import {url} from "../../../../constants"
import { MatchList } from '../MatchList'

const BracketMatchList: FC<BracketMatchListProps> = ({tornamentId}) => {
  const [tours, setTours] = useState<Array<any>>();
  useEffect(() => {
    axios.get(
      `${url}/Tournament/GetTournamentsTours?tournamentId=${tornamentId}`
    ).then(res => {

      setTours(res.data)
    })
  }, [setTours]);
  return (
    <View>
      <Text variant={'titleMedium'}>Матчи play-off:</Text>
      {
        tours?.map(({tourNumber, id, matches}) => (
          <View key={id}>
          <Text variant={"titleMedium"}>Тур №{tourNumber}</Text>
          <MatchList matches={matches}/>
          </View>
        ))
      }
    </View>
  )
}

export default BracketMatchList
