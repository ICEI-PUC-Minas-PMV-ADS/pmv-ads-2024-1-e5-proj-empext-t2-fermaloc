import api from "../api/api";

export async function login(loginDTO) {
  try {
    const response = await await api.post(
      `/fermaloc/v1/administrador/login`,
      loginDTO
    );
    console.log(response.data);
  } catch (err) {
    console.error(err.response.data.message);
  }
}
