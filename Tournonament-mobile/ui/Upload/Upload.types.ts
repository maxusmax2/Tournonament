import type { InputModeOptions } from 'react-native/Libraries/Components/TextInput/TextInput'


export type TextFieldProps = {
  name: string
  label: string
  placeholder: string
  secureTextEntry?: boolean
  inputMode?: InputModeOptions
}

class UploadFile{

  base64!: string
  filename!: string
}


class RegistrationForm  {

  email!: string


  username!: string


  first_name!: string


  last_name!: string


  password!: string

  avatar!: UploadFile
}
export  default RegistrationForm