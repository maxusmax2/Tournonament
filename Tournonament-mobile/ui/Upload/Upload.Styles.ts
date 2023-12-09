import styled from 'styled-components'
import { Image, View } from 'react-native'
import { IconButton } from 'react-native-paper'

export const UploadButton = styled(IconButton)`
  width: 150px;
  height: 150px;
  border-radius: ${({ theme }) => `${theme.roundness}px`};
`

export const UploadImage = styled(Image)`
  width: 150px;
  height: 150px;
  border-radius: ${({ theme }) => `${theme.roundness}px`};
`
