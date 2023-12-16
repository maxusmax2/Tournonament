import {StyleSheet} from 'react-native';
import {TextInput, useTheme } from 'react-native-paper';
import styled from 'styled-components';
import { Image, View } from 'react-native'
import { IconButton } from 'react-native-paper'
export const styles = StyleSheet.create({
  container: {
    backgroundColor: "#14181E",
    flex: 2,

  },
  formWrapper: {
    width: 300,
    gap: 10
  },
  sumbmitButton: {
    backgroundColor: "#704DFF",
    color: "#FFFFFF"
  },
  text: {
    textAlign: 'center',
    color: "#FFFFFF"
  }
});

export const StyledTextInput = styled(TextInput)`
  border-radius: 15px;
  background-color: ${({theme})=>theme.colors.backdrop};
`
export const UploadButton = styled(IconButton)`
  width: 150px;
  height: 150px;
  border-radius: ${({ theme }) => `${theme.roundness}px`};
`

export const UploadImage = styled(Image)`
  width: 100%;
  height: 250px;
  border-radius: 20px;
  align-self: center;
`
