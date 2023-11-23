import { Button } from "react-native-paper"
import {View} from 'react-native'
import {SubmitHandler, useForm} from 'react-hook-form'
import { AuthorizeFormType, authorizeSchema } from "./schemas/authorize.shema"
import {zodResolver} from '@hookform/resolvers/zod'
import FormTextInput from "../../ui/FormTextInput/FormTextInput"
import axios from "axios";
import {
    QueryClient,
    QueryClientProvider,
    useQuery,
  } from 'react-query';
import {url} from "../../constants"
const Authorize = () => {
    const queryClient = new QueryClient()

    const {handleSubmit, control} =
        useForm<AuthorizeFormType>({resolver: zodResolver(authorizeSchema), mode:"onTouched"})
    const handlePress:SubmitHandler<AuthorizeFormType> = (formData) => {
        const { isLoading, error, data } = useQuery('Authorization',
            () =>
                axios.post(
                    url+"",
                    { login: formData.login, password:formData.password}
                ).then((response) => alert(response))
        );
    }
    return(
        <QueryClientProvider client={queryClient}>
        <View style={{flex:1, width:200}}>
           <FormTextInput name={"login"} placeholder={"Логин"} control={control}  icon="login" />
           <FormTextInput name={"password"} placeholder={"Пароль"} control={control}  icon="eye" />
           <Button onPress={handleSubmit(handlePress)} mode="contained">Вход</Button>
        </View>
        </QueryClientProvider>
    )
}

export default Authorize