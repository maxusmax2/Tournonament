import {createNativeStackNavigator} from '@react-navigation/native-stack';
import {Home, Authorize, Registration} from "../../pages";
import {HomeTab} from "../../tabs"
import TournamentDetails from '../../pages/TournamentDetails/TournamentDetails';
import CreateTournamentTab from '../../tabs/CreateTournamentTab';
import ProfileTab from '../../tabs/ProfileTab';

const AuthorizeStack = createNativeStackNavigator();

const AppStack = () => {
  const Stack = createNativeStackNavigator();
  return (
    <Stack.Navigator screenOptions={{headerShown: false}}>
      <Stack.Screen name="Authorize" component={Authorize}/>
      <Stack.Screen name="Registration" component={Registration}/>
      <Stack.Screen name="Bottom" component={HomeTab}/>
      <Stack.Screen name="Profile" component={ProfileTab}/>
      <Stack.Screen name="CreateTournament" component={CreateTournamentTab}/>
      <Stack.Screen name="TournamentDetails" component={TournamentDetails} options={{headerShown: true}}/>
    </Stack.Navigator>
  )
}
export default AppStack