import axios from "axios";
const url = "https://fermaloc.azurewebsites.net/fermaloc/v1/";

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
