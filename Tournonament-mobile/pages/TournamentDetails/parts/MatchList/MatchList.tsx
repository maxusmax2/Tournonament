import { View } from "react-native";
import { MatchListProps } from "./MatchList.types";
import { FC } from "react";
import Match from "../Match/Match";

const MatchList:FC<MatchListProps> = ({matches}) => {

  return(
    <View>
      {matches?.map(({id}) => (<View>
          <Match id={id}/>
      </View>
    ))}
  </View>)
}
export  default MatchList;