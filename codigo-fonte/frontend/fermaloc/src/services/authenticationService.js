import api from "../api/api";

async function loginService(loginDTO) {
    try {
        const response = await api.post(`administrador/login`, loginDTO);
        return response;
    } catch (err) {
        alert(err.response.data.message);
    }
}

async function resetPasswordService(email) {
    try {
        const response = await api.post(`administrador/resetpassword`, {
            email: email,
        });

        return response;
    } catch (err) {
        alert(err.response.data.message);
    }
}

export { loginService, resetPasswordService };
