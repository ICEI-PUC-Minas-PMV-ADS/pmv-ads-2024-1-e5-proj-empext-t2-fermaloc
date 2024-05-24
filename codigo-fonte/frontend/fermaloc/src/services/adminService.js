import axios from "axios";

async function getAdmin(id) {
  try {
    const response = await axios.get(`administrador/${id}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function resetPassword({ email }) {
  try {
    const response = await axios.post(`administrador/resetpassword`, { email });
    return response;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

export { getAdmin, resetPassword };
