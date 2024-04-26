import React, { useState, useEffect } from "react";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js";
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js";
import {
  putProduct,
  changeStatusProduct,
} from "../../../../../services/productService.js";
import { getCategoriesByStatus } from "../../../../../services/categoryService.js";
import InputImageForm from "../../../../../components/InputImageForm/index.js";
import InputSelectForm from "../../../../../components/InputSelectForm/index.js";

export default function EditProductForm({ product, setViewEditForm }) {
  const [categories, setCategories] = useState([]);
  const [name, setName] = useState(product.name);
  const [description, setDescription] = useState(product.description);
  const [equipamentCode, setEquipamentCode] = useState(product.equipamentCode);
  const [status, setStatus] = useState(product.status);
  const [categoryId, setCategoryId] = useState(product.categoryDto.id);
  const [image, setImage] = useState(null);

  useEffect(() => {
    async function fetchCategories() {
      const categoriesData = await getCategoriesByStatus();
      setCategories(categoriesData);
    }
    fetchCategories();
  }, []);

  const submitForm = async (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("Name", name);
    formData.append("Description", description);
    formData.append("EquipamentCode", equipamentCode.toString());
    formData.append("Status", status);
    formData.append("CategoryId", categoryId);
    formData.append("image", image);
    await putProduct(formData, product.id);
    setImage(null);
    setViewEditForm(false);
  };

  const changeStatus = async () => {
    const productUpdated = await changeStatusProduct(product.id);
    setViewEditForm(false);
  };

  return (
    <form onSubmit={submitForm} encType="multipart/form-data">
      <InputForm
        value={name}
        onChange={setName}
        maxLength={150}
        placeholder={"Nome"}
      />
      <TextAreaForm
        value={description}
        onChange={setDescription}
        maxLength={1000}
      />
      <InputForm
        value={equipamentCode}
        type="number"
        onChange={setEquipamentCode}
      />
      <SelectStatusForm value={status} onChange={setStatus} />
      <InputSelectForm
        options={categories}
        selectedOption={categoryId}
        onChange={setCategoryId}
      />
      <img
        src={`data:image/png;base64,${product.image}`}
        alt="produto"
        style={{ width: "100px" }}
      />
      <InputImageForm handleImageChange={(e) => setImage(e.target.files[0])} />
      <button type="submit">Enviar</button>
      <button type="button" onClick={changeStatus}>
        Alterar Status
      </button>
      <button type="button" onClick={() => setViewEditForm(false)}>
        Cancelar
      </button>
    </form>
  );
}
