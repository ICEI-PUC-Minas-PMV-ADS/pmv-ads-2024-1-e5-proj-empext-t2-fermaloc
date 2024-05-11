import React, { useState } from "react";
import styles from "./styles.module.css";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js";
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js";
import { postCategory } from "../../../../../services/categoryService.js";
import useAuthentication from "../../../../../hooks/useAuthentication.js";

export default function NewCategoryForm() {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [status, setStatus] = useState(true);

  const { getAdminId } = useAuthentication();

  const validateForm = () => {
    if (name.trim() === "" || description.trim() === "") {
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
    const categoryCreated = await postCategory({
      name,
      description,
      status,
      administratorId,
    });
    setName("");
    setDescription("");
    setStatus(true);
    window.location.reload();
  };

  return (
    <form onSubmit={submitForm}>
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
      <div className={styles.page}>
        <button type="submit">Enviar</button>
      </div>
    </form>
  );
}
