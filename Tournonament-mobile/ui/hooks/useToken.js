import { useEffect, useState } from 'react'
import * as SecureStore from 'expo-secure-store'

const useToken = () => {
    const [token, setToken] = useState('')

    useEffect(() => {
        SecureStore.getItemAsync('token').then((data) => setToken(data))
    }, [])
    return token
}
export  default  useToken;