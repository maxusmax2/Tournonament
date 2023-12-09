import { useState, useEffect } from 'react'
import { useFormContext } from 'react-hook-form'
import { View } from 'react-native'
import { HelperText } from 'react-native-paper'
import { launchImageLibraryAsync, MediaTypeOptions } from 'expo-image-picker'

import { UploadButton, UploadImage } from './Upload.Styles'
import RegistrationForm from './Upload.types'
import type { FC } from 'react'



