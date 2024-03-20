import url from '../api/url';
import axios from 'axios';

// Fazer o login

export async function login(loginDTO) {
    const response = await axios.get(`${url}/fermaloc/v1/administrador/login`, loginDTO);
    return response.data;
}