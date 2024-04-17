import React, { useState, useEffect } from "react";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js";
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js";
import { postProduct } from "../../../../../services/productService.js";
import { getActiveCategories } from "../../../../../services/categoryService.js";
import useAuthentication from "../../../../../hooks/useAuthentication.js";
import InputImageForm from "../../../../../components/InputImageForm/index.js";
import InputSelectForm from "../../../../../components/InputSelectForm/index.js";

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
      const categoriesData = await getActiveCategories();
      setCategories(categoriesData);
    }
    fetchCategories();
  }, []);

  const submitForm = (e) => {
    e.preventDefault();
    const administratorId = getAdminId()
    const formData = new FormData();
    formData.append("Name", name)
    formData.append("Description", description)
    formData.append("EquipamentCode", parseInt(equipamentCode))
    formData.append("Status", status)
    formData.append("AdministratorId", administratorId)
    formData.append("CategoryId", categoryId)
    formData.append("image", image)
    postProduct(formData);

    setName("");
    setDescription("");
    setEquipamentCode(0);
    setCategoryId();
    setImage(null);
    setStatus(true);
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
      <InputSelectForm options={categories} selectedOption={categoryId} onChange={setCategoryId}/>
      <InputImageForm handleImageChange={(e) => setImage(e.target.files[0])} />
      <button type="submit">Enviar</button>
    </form>
  );
}
