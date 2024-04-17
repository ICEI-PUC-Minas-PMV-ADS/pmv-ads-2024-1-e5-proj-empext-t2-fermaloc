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

  const submitForm = (e) => {
    e.preventDefault();
    const administratorId = getAdminId();
    const categoryUpdated = putCategory({
      name,
      description,
      status,
      administratorId,
      categoryId: category.id,
    });
    setViewEditForm(false);
  };

  const changeStatus = () => {
    const categoryUpdated = changeStatusCategory(category.id);
    setViewEditForm(false);
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
