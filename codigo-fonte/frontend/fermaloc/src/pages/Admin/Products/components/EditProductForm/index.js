import React, { useState, useEffect } from "react";
import InputForm from "../../../../../components/InputForm/index.js";
import styles from "./styles.module.css";
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

  const validateForm = () => {
    if (
      name.trim() === "" ||
      description.trim() === "" ||
      equipamentCode <= 0 ||
      categoryId.trim() === "" ||
      !image
    ) {
      alert(
        "Por favor, preencha todos os campos antes de enviar o formulário."
      );
      return false;
    }
    return true;
  };

  const submitForm = async (e) => {
    e.preventDefault();
    if (!validateForm()) {
      return;
    }
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
    window.location.reload();
  };

  const changeStatus = async () => {
    const productUpdated = await changeStatusProduct(product.id);
    setViewEditForm(false);
    window.location.reload();
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
      
      <div className={styles.page}>
        <img
        src={`data:image/png;base64,${product.image}`}
        alt="produto"
        style={{ width: "100px" }}
      /></div>
      <InputImageForm handleImageChange={(e) => setImage(e.target.files[0])} />
      <div className={styles.page}>
      <button type="submit">Enviar</button>
      <button type="button" onClick={changeStatus}>
        Alterar Status
      </button>
      <button type="button" onClick={() => setViewEditForm(false)}>
        Cancelar
      </button></div>
    </form>
  );
}
