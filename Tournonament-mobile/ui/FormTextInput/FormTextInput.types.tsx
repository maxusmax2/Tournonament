import type { KeyboardType } from 'react-native'
import type { FieldValues } from 'react-hook-form'

export type FormTextInputProps = FieldValues & {
  name: string,
  placeholder: string,
  icon?: string
  multiline?:boolean
  inputType?:KeyboardType
}