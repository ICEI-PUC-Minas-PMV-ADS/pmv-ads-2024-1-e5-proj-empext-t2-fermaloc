import axios from "axios";
//const url = "http://localhost:5175/fermaloc/v1/";
const url = "https://localhost:7020/fermaloc/v1/";

const api = axios.create({
    baseURL: url,
    timeout: 10000,
    headers: {
        common: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    },
});
export default api;
