import {url} from "../../constants"
import RNDateTimePicker, {DateTimePickerAndroid, DateTimePickerEvent} from '@react-native-community/datetimepicker';
import {StyledTextInput, UploadImage, styles} from './Registration.styles'
import {Button, TextInput} from "react-native-paper"
import {View, Pressable,Image} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import {QueryClient, QueryClientProvider} from "react-query"
import FormTextInput from "../../ui/FormTextInput/FormTextInput"
import {SubmitHandler, useForm} from "react-hook-form"
import {RegistrationFormType} from "./Registration.types"
import axios from "axios"
import React, {useState,} from "react";
import DateTimePicker from "@react-native-community/datetimepicker";
import * as SecureStore from 'expo-secure-store';
const Registration = () => {

  // @ts-ignore
  const [date, setDate] = useState(new Date());
  const [show, setShow] = useState(false)


  // @ts-ignore
  const onChange = (e, selectedDate) => {
    setShow(false)
    setDate(selectedDate);
    console.log(date)
  };
  const queryClient = new QueryClient()
  const navigation = useNavigation<NavigationScreensType>()
  const {handleSubmit, control} =
    useForm<RegistrationFormType>()

  const handlePress: SubmitHandler<RegistrationFormType> = (formData) => {
    //@ts-ignore
    console.log({login: formData.Login, password: formData.Password,birthday:date.toDateString(),nickName:formData.NickName,role:"Player"})
    axios.post(
      `${url}/User`,
      {login: formData.Login, password: formData.Password,birthday:date.toUTCString(),nickName:formData.NickName,role:"Player",aboutMe:formData.AboutMe}
    ).then(async (response) =>
    {
      await SecureStore.setItemAsync("token",response.data.token)

      console.log("tokenStorage", await SecureStore.getItemAsync("token"))
      await SecureStore.setItemAsync("user",JSON.stringify(response.data.user))
      navigation.navigate("Bottom", {response: response.data.user})
    })

      .catch(error=> console.log(error.message))
  }

  const toAuth = () => {
    navigation.navigate("Authorize");
  }
  // @ts-ignore
  return (
    <QueryClientProvider client={queryClient}>
      <View style={styles.container}>
        <View style={styles.formWrapper}>

          <FormTextInput name={"Login"} placeholder={"Логин"} control={control}
                         icon="login" />
          <FormTextInput name={"Password"} placeholder={"Пароль"} control={control}
                         icon="eye" secureTextEntry/>
          <FormTextInput name={"NickName"} placeholder={"Ник"} control={control}
                         icon="account"/>

          {show && (<DateTimePicker
            value={date || new Date()}
            mode={"date"}
            is24Hour={true}
            display="default"
            onChange={onChange}
          />)}
          <Pressable onPress={() => setShow(true)}>
            <StyledTextInput left={<TextInput.Icon icon={'cake-variant'}/>} underlineStyle={{display: 'none'}}
                             editable={false}>{date.toLocaleDateString()}</StyledTextInput>
          </Pressable>
          <FormTextInput name={"AboutMe"} placeholder={"О себе"} control={control} multiline={true}
                         icon="information" secureTextEntry/>
          <Button contentStyle={styles.sumbmitButton} onPress={handleSubmit(handlePress)}>Зарегистрироваться</Button>
        </View>
      </View>
    </QueryClientProvider>
  )
}

export default Registration