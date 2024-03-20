import axios from "axios";
const url = "http://localhost:5095"; // NÃO ATUALIZAR, diferente para cada PC.

const api = axios.create({
    baseURL: url,
    timeout: 10000,
    auth: localStorage.getItem("token")
})
export default api;