import {Pressable, ScrollView, View } from "react-native";
import { Button, TextInput } from "react-native-paper";
import {QueryClient, QueryClientProvider } from "react-query";
import FormTextInput from "../../ui/FormTextInput/FormTextInput";
import { StyledTextInput, styles } from "../CreateTournament/CreateTournament.styles";
import React, {useEffect, useState } from "react";
import { useNavigation } from "@react-navigation/native";
import { CreateTournamentTypesFormType } from "./CreateTournament.types";
import {SubmitHandler, useForm } from "react-hook-form";
import { RegistrationFormType } from "../Registration/Registration.types";
import axios from "axios";
import DateTimePicker from "@react-native-community/datetimepicker";
import { url } from "../../constants";
import { NavigationScreensType } from "../../navigate/Navigate.type";
import * as SecureStore from 'expo-secure-store';
import ToggleSwitch from "toggle-switch-react-native";
const CreateTournament = () =>
{
  // @ts-ignore
  const [date, setDate] = useState(new Date());
  const [show, setShow] = useState(false)
  const [user,setUser] = useState<any>()
  const [groupPlayOffSwitch, setGroupPlayOffSwitch] = useState(true);
   useEffect(() => {

    SecureStore.getItemAsync("user").then(res => setUser(JSON.parse(res ?? "")))

  }, [null]);
  const navigation = useNavigation<NavigationScreensType>()
  const onGroupPlayOffSwitch = () => setGroupPlayOffSwitch(!groupPlayOffSwitch)
  // @ts-ignore
  const onChange = (e, selectedDate) => {
    setShow(false)
    setDate(selectedDate);
    console.log(date)
  };
  const queryClient = new QueryClient()
  const {handleSubmit, control} =
    useForm<CreateTournamentTypesFormType>()

  const handlePress: SubmitHandler<CreateTournamentTypesFormType> = (formData) => {
    axios.post(
      `${url}/Tournament`,
      {name: formData.Name, date: date.toUTCString(), description: formData.Description, participantNumberMax: Number(formData.ParticipantNumberMax),
        prizeFund: Number(formData.PrizeFund),format:1,withGroupStep:groupPlayOffSwitch,groupNumber:Number(formData.GroupNumber),
        location: formData.Location, numberLeavingTheGroup:Number(formData.NumberLeavingTheGroup),creatorId:user?.id,
        discipline: formData.Discipline}
    ).then(async (response) =>
    {
      console.log("IDшник",response.data.id)
      navigation.navigate("TournamentDetails", {response:response.data.id})
    })
      .catch(error=> console.log(error))
  }

  const toAuth = () => {
    navigation.navigate("Authorize");
  }

  return (
    <QueryClientProvider client={queryClient}>
      <ScrollView style={styles.container}>
        <View style={styles.formWrapper}>

          <FormTextInput name={"Name"} placeholder={"Имя"} control={control}
                         icon="eye" />
          <FormTextInput name={"Description"} placeholder={"Описание"} control={control}
                         icon="eye" secureTextEntry multiline={true}/>
          <FormTextInput name={"ParticipantNumberMax"} placeholder={"Кол-во участников"} control={control}
                         icon="account"/>
          <FormTextInput name={"GroupNumber"} placeholder={"Количество групп"} control={control}
                         icon="account"/>
          <FormTextInput name={"PrizeFund"} placeholder={"Призовой фонд"} control={control}
                         icon="account"/>
          <FormTextInput name={"Location"} placeholder={"Адрес"} control={control}
                         icon="eye"/>
          <FormTextInput name={"NumberLeavingTheGroup"} placeholder={"Кол-во людей из группы"} control={control}
                         icon="eye"/>

            <ToggleSwitch
              isOn={groupPlayOffSwitch}
              onColor="blue"
              offColor="green"
              label="Без/Группа"
              labelStyle={{color: "white", fontWeight: "900"}}
              size="large"
              onToggle={onGroupPlayOffSwitch}
            />
          <FormTextInput name={"Discipline"} placeholder={"Дисциплина"} control={control}
                         icon="eye"/>

          {show && (<DateTimePicker
            value={date || new Date()}
            mode={"date"}
            is24Hour={true}
            display="default"
            onChange={onChange}
          />)}
          <Pressable onPress={() => setShow(true)}>
            <StyledTextInput left={<TextInput.Icon icon={'eye'}/>} underlineStyle={{display: 'none'}}
                             editable={false}>{date.toLocaleDateString()}</StyledTextInput>
          </Pressable>

          <Button contentStyle={styles.sumbmitButton} onPress={handleSubmit(handlePress)}>Создать</Button>
        </View>
      </ScrollView>
    </QueryClientProvider>
  )
}
export  default  CreateTournament