import axios from "axios";

async function getAdmin(id) {
  try {
    const response = await axios.get(`administrador/${id}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

export { getAdmin };
