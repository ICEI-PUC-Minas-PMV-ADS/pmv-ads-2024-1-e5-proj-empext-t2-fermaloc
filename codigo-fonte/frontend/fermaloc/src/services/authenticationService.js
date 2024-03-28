import api from "../api/api";

async function login(loginDTO) {
  try {
    const response = await api.post(`administrador/login`, loginDTO);
    console.log(response.data);
  } catch (err) {
    console.error(err.response.data.message);
  }
}

function logout() {
  localStorage.removeItem("token");
}

export { login, logout };
