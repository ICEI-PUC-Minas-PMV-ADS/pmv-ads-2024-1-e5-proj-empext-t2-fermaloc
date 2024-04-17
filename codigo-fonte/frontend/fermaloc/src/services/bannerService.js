import api from "../api/api";

async function getBanner() {
  try {
    const response = await api.get(`banner`);
    return response.data;
  } catch (err) {
    console.error(err);
  }
}

async function putBanner(formData) {
  try {
    const response = await api.put(`banner`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return response.data;
  } catch (err) {
    console.error(err);
  }
}

export { getBanner, putBanner };
