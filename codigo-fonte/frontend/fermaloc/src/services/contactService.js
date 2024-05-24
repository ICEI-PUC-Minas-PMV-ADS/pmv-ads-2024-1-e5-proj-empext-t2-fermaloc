import api from "../api/api.js"

async function makeContact({ message, email, phoneNumber1, phoneNumber2 }) {
  try {
    const response = await api.post(`contact/`, {
      message,
      email,
      phoneNumber1,
      phoneNumber2,
    });
    return response;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

export { makeContact };
