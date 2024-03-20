import api from '../api/api';
import axios from 'axios';

export async function login(loginDTO) {
    const response = await api.get(`/fermaloc/v1/administrador/login`, loginDTO);
    return response.data;
}