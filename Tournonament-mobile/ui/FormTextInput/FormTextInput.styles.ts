import styled from 'styled-components'
import { TextInput } from 'react-native-paper'
import { View } from 'react-native'

export const FormTextInputRoot = styled(View)`
  flex-direction: row;
  gap: 15px;
`

export const FormTextInputWrapper = styled(TextInput)`
  flex: 1;
  border-radius: 15px;
  background-color: ${({theme})=>theme.colors.backdrop};
`