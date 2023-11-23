import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { Home } from './pages/Home';
import {PaperProvider, MD3DarkTheme as darkTheme, MD3LightTheme as lightTheme} from 'react-native-paper'
import { ThemeProvider } from 'styled-components';
import { Authorize } from './pages/Authorize';
import { Navigate } from './navigate';

export default function App() {
  const mode = 'dark'
  const theme = mode === 'dark'? darkTheme: lightTheme
  return (
    <PaperProvider theme={theme}>
      <ThemeProvider theme={theme}>
        <Navigate/>

        </ThemeProvider>
    </PaperProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
