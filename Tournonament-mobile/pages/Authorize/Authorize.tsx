import {Button, Text} from "react-native-paper"
import {View} from 'react-native'
import {SubmitHandler, useForm} from 'react-hook-form'
import {AuthorizeFormType, authorizeSchema} from "./schemas/authorize.shema"
import {zodResolver} from '@hookform/resolvers/zod'
import FormTextInput from "../../ui/FormTextInput/FormTextInput"
import {styles} from "./Authorize.styles"
import axios from "axios";
import {
  QueryClient,
  QueryClientProvider,
  useQuery,
} from 'react-query';
import {NavigationScreensType} from '../../navigate/Navigate.type'
import {url} from "../../constants"
import {useNavigation} from "@react-navigation/native"

const Authorize = () => {
  const queryClient = new QueryClient()
  const navigation = useNavigation<NavigationScreensType>()
  const {handleSubmit, control} =
    useForm<AuthorizeFormType>({resolver: zodResolver(authorizeSchema), mode: "onTouched"})
  const handlePress: SubmitHandler<AuthorizeFormType> = (formData) => {
    axios.post(
      `${url}/Auth`,
      {login: formData.login, password: formData.password}
    ).then((response) => navigation.navigate("Bottom", {response: response.data}))
  }
  const toRegistration  = () =>
  {
    navigation.navigate("Registration");
  }
  return (
    <QueryClientProvider client={queryClient}>
      <View style={styles.container}>
        <View style={styles.formWrapper}>
          <Text style={styles.text} variant={'titleLarge'}>Авторизация</Text>
          <FormTextInput name={"login"} placeholder={"Логин"} control={control}
                         icon="login"/>
          <FormTextInput name={"password"} placeholder={"Пароль"} control={control}
                         icon="eye" secureTextEntry/>
          <Button contentStyle={styles.sumbmitButton} onPress={handleSubmit(handlePress)}>Войти</Button>
          <Button contentStyle={styles.sumbmitButton} onPress={toRegistration}>Регистрация</Button>
        </View>
      </View>
    </QueryClientProvider>
  )
}

export default Authorize