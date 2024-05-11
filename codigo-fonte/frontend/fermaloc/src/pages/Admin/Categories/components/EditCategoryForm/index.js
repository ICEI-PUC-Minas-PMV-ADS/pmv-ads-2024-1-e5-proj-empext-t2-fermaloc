import React, { useState } from "react";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js";
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js";
import {
  putCategory,
  changeStatusCategory,
} from "../../../../../services/categoryService.js";
import useAuthentication from "../../../../../hooks/useAuthentication.js";

export default function EditCategoryForm({ category, setViewEditForm }) {
  const [name, setName] = useState(category.name);
  const [description, setDescription] = useState(category.description);
  const [status, setStatus] = useState(category.status);

  const { getAdminId } = useAuthentication();

  const validateForm = () => {
    if (name.trim() === "" || description.trim() === "") {
      alert("Por favor, preencha todos os campos antes de enviar o formulário.");
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
    const categoryUpdated = await putCategory({
      name,
      description,
      status,
      administratorId,
      categoryId: category.id,
    });
    setViewEditForm(false);
    window.location.reload();
  };

  const changeStatus = async () => {
    const categoryUpdated = await changeStatusCategory(category.id);
    setViewEditForm(false);
    window.location.reload();
  };

  return (
    <form>
      <InputForm
        value={name}
        onChange={setName}
        maxLength={50}
        placeholder={"Nome"}
      />
      <TextAreaForm
        value={description}
        onChange={setDescription}
        maxLength={300}
      />
      <SelectStatusForm value={status} onChange={setStatus} />
      <button type="button" onClick={(e) => submitForm(e)}>
        Enviar
      </button>
      <button type="button" onClick={changeStatus}>
        Alterar Status
      </button>
      <button type="button" onClick={() => setViewEditForm(false)}>
        Cancelar
      </button>
    </form>
  );
}
