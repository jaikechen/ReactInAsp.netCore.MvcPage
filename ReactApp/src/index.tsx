import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Combobox from './components/MyAutoComplete';

const containers = document.querySelectorAll('.auto-complete');
containers.forEach(x => {
    const ds = (x as any).dataset;
    console.log(ds.options);
    const options = JSON.parse(ds.options);
    const bind:string = ds.bind;
    ReactDOM.render(<Combobox bind={bind} options={options} />, x);
});
