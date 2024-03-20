import url from '../api/url';
import axios from 'axios';

export async function getAdmin(id) {
    const response = await axios.get(`${url}/fermaloc/v1/administrador/${id}`);
    return response.data;
}