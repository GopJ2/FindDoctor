import axios from "axios";
import {AsyncStorage} from 'react-native';

const URI = 'http://192.168.0.100:5000';

let Api = axios.create({
    baseURL: URI
});

Api.interceptors.request.use((config) => {
    AsyncStorage.getItem('token').then(res => {
        if (res !== null && res !== '') {
            config.headers.credentials = 'include';
            config.headers.Authorization = `${res}`;
            config.headers['Access-Control-Allow-Origin'] = '*';
            config.headers['Content-Type'] = 'application/json';
        }else {
            config.headers.credentials = '';
            config.headers.Authorization = '';
            config.headers['Access-Control-Allow-Origin'] = '*';
            config.headers['Content-Type'] = 'application/json';
        }
    })

    return config;
}, (error) => {
    return Promise.reject(error);
});

export default Api;