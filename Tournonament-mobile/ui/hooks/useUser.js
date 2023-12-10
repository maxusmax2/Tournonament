import * as SecureStore from 'expo-secure-store'

const useUser = () => {
    const [user, setUser] = useState('')

    useEffect(() => {
        SecureStore.getItemAsync('user').then((data) => setUser(data))
    }, [])
    return user
}
export  default  useUser;