import { StackNavigationProp } from "@react-navigation/stack"

export type StackScreenList = 
{
    Authorize: undefined
    Home: any
    Bottom: any
    Registration: undefined
    TournamentDetails: any
    CreateTournament: any
}
export type NavigationScreensType = StackNavigationProp<StackScreenList>