import { HelperText, TextInput } from 'react-native-paper'
import { Controller } from 'react-hook-form'
import { View } from 'react-native'


import { FormTextInputRoot, FormTextInputWrapper } from './FormTextInput.styles'

import type { FC } from 'react'
import type { FormTextInputProps } from './FormTextInput.types'

const FormTextInput: FC<FormTextInputProps> =
  ({
    control,
    defaultValue,
    name,
    placeholder,
    icon,
    multiline = false,
    errorMessage = '',
    inputType = 'default'
   }) => (
    <View>
      <FormTextInputRoot>
        <Controller
          control={control}
          render={({ field: { onChange, value, onBlur } }) => (
            <FormTextInputWrapper
              multiline={multiline}
              left={icon && <TextInput.Icon icon={icon} />}
              onChangeText={onChange}
              onBlur={onBlur}
              value={value}
              placeholder={placeholder}
              underlineColor={'transparent'}
              activeUnderlineColor={'transparent'}
              keyboardType={inputType}
            />
          )}
          defaultValue={defaultValue || ''}
          name={name}
        />
      </FormTextInputRoot>
      {errorMessage && <HelperText type='error'>
        {errorMessage}
      </HelperText>
      }
    </View>
  )

export default FormTextInput