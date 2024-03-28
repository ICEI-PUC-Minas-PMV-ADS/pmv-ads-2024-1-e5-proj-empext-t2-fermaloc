import api from "../api/api";

async function getCategories() {
  try {
    const response = await api.get(`categoria`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getCategoryById(id) {
  try {
    const response = await api.get(`categoria/${id}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

export { getCategories, getCategoryById };
