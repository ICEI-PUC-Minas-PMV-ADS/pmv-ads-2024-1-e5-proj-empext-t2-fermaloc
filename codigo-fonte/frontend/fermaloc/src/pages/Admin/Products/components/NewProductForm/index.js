import React, { useState, useEffect } from "react";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js";
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js";
import { postProduct } from "../../../../../services/productService.js";
import { getCategoriesByStatus } from "../../../../../services/categoryService.js";
import useAuthentication from "../../../../../hooks/useAuthentication.js";
import InputImageForm from "../../../../../components/InputImageForm/index.js";
import InputSelectForm from "../../../../../components/InputSelectForm/index.js";
import styles from "./styles.module.css";

export default function NewProductForm() {
  const [categories, setCategories] = useState([]);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [equipamentCode, setEquipamentCode] = useState(0);
  const [status, setStatus] = useState(true);
  const [categoryId, setCategoryId] = useState("");
  const [image, setImage] = useState(null);

  const { getAdminId } = useAuthentication();

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
    const administratorId = getAdminId();
    const formData = new FormData();
    formData.append("Name", name);
    formData.append("Description", description);
    formData.append("EquipamentCode", equipamentCode.toString());
    formData.append("Status", status);
    formData.append("CategoryId", categoryId);
    formData.append("image", image);
    formData.append("AdministratorId", administratorId);
    await postProduct(formData);

    setName("");
    setDescription("");
    setEquipamentCode(0);
    setCategoryId();
    setImage(null);
    setStatus(true);
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
      <InputImageForm handleImageChange={(e) => setImage(e.target.files[0])} />
      <div className={styles.page}>
        <button type="submit">Enviar</button>
      </div>
    </form>
  );
}
