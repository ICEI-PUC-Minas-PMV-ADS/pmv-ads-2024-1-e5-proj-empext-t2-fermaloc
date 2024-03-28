import api from "../api/api";

async function getBanners() {
  try {
    const response = await api.get(`banner`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getBannerById(id) {
  try {
    const response = await api.get(`banner/${id}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

export { getBanners, getBannerById };
