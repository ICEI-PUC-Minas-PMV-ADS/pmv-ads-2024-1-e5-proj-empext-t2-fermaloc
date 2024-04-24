//O parâmetro page nas funções ainda não tem utilidade no backend. Ele terá a função de indicar em qual página o usuário esta. Depois será necessário remover o "= 1"

import api from "../api/api";

async function getProducts(page = 1) {
  try {
    const response = await api.get(`equipamento?skip=${page}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getTopProducts(page = 1) {
  try {
    const response = await api.get(`equipamento/topequipamentos?skip=${page}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getSimalarProducts(productId, categoryId) {
  try {
    const response = await api.get(
      `equipamento/equipamentossimilares?productId=${productId}&categoryId=${categoryId}`
    );
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getProductById(id) {
  try {
    const response = await api.get(`equipamento/${id}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getProductByStatus(status = true, page = 1) {
  try {
    const response = await api.get(
      `equipamento/status?skip=${page}&status=${status}`
    );
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function getProductByStatusAndCategory(status, categoryId, page = 1) {
  try {
    const response = await api.get(
      `equipamento/statusaecategoria?skip=${page}&status=${status}&categoryId=${categoryId}`
    );
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

//O parâmetro page ainda não foi nem passado na requisição pois esse endpont no backend ainda não está aceitando esse parâmetro
async function getProductBySearchedName(nameEquipament, page = 1) {
  try {
    const response = await api.get(
      `equipamento/pesquisa?nameEquipament=${nameEquipament}`
    );
    return response.data;
  } catch (err) {
    console.error(err.response.data.message);
  }
}

async function postProduct(formData) {
  try {
    console.log(formData);
    const response = await api.post(`equipamento/`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}

async function putProduct(formData, productId) {
  try {
    const response = await api.put(`equipamento/${productId}`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    console.log(response)
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}

async function changeStatusProduct(productId) {
  try {
    const response = await api.put(`equipamento/alterarstatus/${productId}`);
    return response.data;
  } catch (err) {
    console.error(err.response.data.errors);
  }
}

export {
  getProducts,
  getProductById,
  getProductBySearchedName,
  getProductByStatus,
  getProductByStatusAndCategory,
  getTopProducts,
  getSimalarProducts,
  postProduct,
  putProduct,
  changeStatusProduct,
};
