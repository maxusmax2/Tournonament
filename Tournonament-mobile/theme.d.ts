import 'styled-components'
import { MD3Theme as PaperDefaultTheme } from 'react-native-paper'
declare module 'styled-components' {
  export interface DefaultTheme extends PaperDefaultTheme{}
}