import {url} from "../../constants"
import RNDateTimePicker, {DateTimePickerAndroid, DateTimePickerEvent} from '@react-native-community/datetimepicker';
import {StyledTextInput, UploadImage, styles} from './Registration.styles'
import {Button, TextInput} from "react-native-paper"
import {View, Pressable,Image} from "react-native"
import {useNavigation} from "@react-navigation/native"
import {NavigationScreensType} from '../../navigate/Navigate.type'
import {QueryClient, QueryClientProvider} from "react-query"
import FormTextInput from "../../ui/FormTextInput/FormTextInput"
import mime from "mime"
import {SubmitHandler, useForm} from "react-hook-form"
import {RegistrationFormType} from "./Registration.types"
import axios from "axios"
import React, {useState,} from "react";
import DateTimePicker from "@react-native-community/datetimepicker";
import * as ImagePicker from 'expo-image-picker';
const Registration = () => {

  const [image, setImage] = useState<string|undefined>();
  const [imageInfo,setImageInfo] = useState(null)

  const pickImage = async () => {
    // No permissions request is necessary for launching the image library
    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.All,
      allowsEditing: true,
      aspect: [4, 3],
      quality: 1,
    });

    console.log(result);

    if (!result.canceled) {
      // @ts-ignore
      setImage(result.assets[0].uri);
      // @ts-ignore
      setImageInfo(result.assets[0])
    }
  };
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
    console.log( imageInfo.type)
    let bodyFormData = new FormData()
    bodyFormData.append("NickName",formData.NickName)
    //@ts-ignore
    bodyFormData.append("Birthday",date)
    bodyFormData.append("AboutMe",formData.AboutMe)
    bodyFormData.append("Password",formData.Password)
    bodyFormData.append("Login",formData.Login)
    bodyFormData.append("Role",'Player')
    //@ts-ignore
    const newImageUri =  "file:///" + imageInfo.uri.split("file:/").join("");
    //@ts-ignore
    bodyFormData.append("avatar", {uri:newImageUri ,type: mime.getType(newImageUri), name: newImageUri.split("/").pop()})
    console.log(bodyFormData);

    fetch(`${url}/User`,{
        method:"POST",
        headers: { "Content-Type": "multipart/form-data", },
        body: bodyFormData,
        }

    ).then((response) => {

      navigation.navigate("Bottom", {response: response.data})
    }).catch(error=> console.log(error.message));
  }
  const toRegistration = () => {
    navigation.navigate("Registration");
  }
  // @ts-ignore
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
          <Button contentStyle={styles.sumbmitButton} onPress={()=>pickImage()}>Загрузить фото</Button>
          <UploadImage source={{uri:image}}/>
          <Button contentStyle={styles.sumbmitButton} onPress={handleSubmit(handlePress)}>Зарегистрироваться</Button>
        </View>
      </View>
    </QueryClientProvider>
  )
}

export default Registration