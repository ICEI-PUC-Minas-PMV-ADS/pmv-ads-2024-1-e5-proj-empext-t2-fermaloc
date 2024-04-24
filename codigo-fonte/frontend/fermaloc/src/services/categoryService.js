import api from "../api/api";

async function getCategories() {
  try {
    const response = await api.get(`categoria`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getCategoriesByStatus(status = true) {
  try {
    const response = await api.get(`categoria/status?status=${status}`);
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

async function postCategory({ name, description, status, administratorId }) {
  try {
    const response = await api.post(`categoria/`, {
      name,
      description,
      status,
      administratorId,
    });
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}

async function putCategory({ name, description, status, administratorId, categoryId }) {
  try {
    const response = await api.put(`categoria/${categoryId}`, {
      name,
      description,
      status,
      administratorId,
    });
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}

async function changeStatusCategory(categoryId) {
  try {
    const response = await api.put(`categoria/alterarstatus/${categoryId}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}





export { getCategories, getCategoryById, postCategory, putCategory, changeStatusCategory, getCategoriesByStatus};
