import React from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';

interface OptionModel {
    id: number;
    name: string;
}

interface PropModel {
    bind: string
    options:OptionModel[]
}

export default (props: PropModel) => {
    const {bind, options } = props;

    const setValue = (val:OptionModel|null) => {
        const ele = document.getElementById(bind) as any;
        ele.value= val? val.id: val;
    }

    return (
        <Autocomplete
            options={options}
            getOptionLabel={(option) => option.name}
            style={{ width: 300 }}
            renderInput={(params) => <TextField {...params} label="" variant="outlined" />}
            onChange={(event: any, newValue: OptionModel | null) => {setValue(newValue)}}
        />
    );
}