import { FC, useEffect, useState } from "react";
import { View } from "react-native";
import { MatchProps } from "./Match.types";
import axios from "axios";
import { url } from "../../../../constants/Constants";
import {Button, Card, Modal, PaperProvider, Portal, Text} from "react-native-paper"
import { styles } from "./Match.styles";
import CloseMatch from "../CloseMatch/CloseMatch";
import * as SecureStore from 'expo-secure-store';
const Match:FC<MatchProps> = ({id}) => {
  const [user,setUser] = useState<any>()
  const [match, setMatch] = useState<any>();
  const [visible, setVisible] = useState(false);
  useEffect(() => {
    SecureStore.getItemAsync("user").then(res => setUser(JSON.parse(res ?? "")))
    axios.get(
      `${url}/Match/${id}`
    ).then(res => {
      console.log("match", res.data.scores)
      setMatch(res.data)
    })
  }, [setMatch]);

  const isParticipants = () : boolean =>
  {
    let result = false
    match?.participants?.forEach((player: any )=>
    {
      if(player?.id == user?.id) result = true;
    });
    return result;
  }
  const  viewModelChangeScore = (id:number)=>
  {
    setVisible(true);
  }
  const  hideModal = ()=>
  {
    setVisible(false);
  }
  return(
    <View key={id}>
      <Card key={id}>
        <Card.Title title={"Матч№"+match?.number}/>
        <Card.Content>
        </Card.Content>
        <Card.Actions>
          <Text variant="bodyMedium">{match?.participants[0]?.nickName ?? "TND"} VS {match?.participants[1]?.nickName ?? "TND"}</Text>
          <Text variant="bodyMedium">{match?.scores[0]?.value ?? 0}:{match?.scores[1]?.value ?? 0}</Text>
          {match?.status !=2 && isParticipants() && <Button mode="contained" onPress={()=>viewModelChangeScore(match?.id)}>Закрыть счет</Button>}
        </Card.Actions>
      </Card>

      <Portal>
      <Modal visible={visible} onDismiss={hideModal} contentContainerStyle={styles.modalContainer}>
        <CloseMatch match={match} visibleChange={setVisible}/>
      </Modal>
        </Portal>
    </View>)

}
export  default Match;