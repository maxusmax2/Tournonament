import DateTimePicker  from "@react-native-community/datetimepicker";
import { Controller } from "react-hook-form";


//@ts-ignore
const DatePicker = ({ control, name, value, onChange }) => {
  return (
    <Controller
      control={control}
      name={name}
      defaultValue={value}
      render={({ field: { onChange, value } }) => (
        <DateTimePicker
          value={value || new Date()} // Provide a default value if value is empty
          mode={"date"} // You can use "time" or "datetime" for different modes
          is24Hour={true}
          display="default"
          onChange={(event, selectedDate) => {
            onChange(selectedDate);
          }}
        />
      )}
    />
  );
};
export default DatePicker