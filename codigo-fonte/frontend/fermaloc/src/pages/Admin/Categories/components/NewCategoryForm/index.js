import React, { useState } from "react";
import styles from "./styles.module.css";
import InputForm from "../../../../../components/InputForm/index.js";
import TextAreaForm from "../../../../../components/TextAreaForm/index.js"
import SelectStatusForm from "../../../../../components/SelectStatusForm/index.js"
import { postCategory } from "../../../../../services/categoryService.js";
import useAuthentication from "../../../../../hooks/useAuthentication.js";

export default function NewCategoryForm() {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [status, setStatus] = useState(true);

  const { getAdminId } = useAuthentication();

  const submitForm = async (e) => {
    e.preventDefault();
    const administratorId = getAdminId();
    const categoryCreated = await postCategory({name, description, status, administratorId})
    setName("");
    setDescription("");
    setStatus(true);
  };

  return (
    <form onSubmit={submitForm}>
      <InputForm
        value={name}
        onChange={setName}
        maxLength={50}
        placeholder={"Nome"}
      />
      <TextAreaForm value={description} onChange={setDescription} maxLength={300}/>
      <SelectStatusForm value={status} onChange={setStatus}/>
      <div className={styles.page}><button type="submit">Enviar</button></div>
    </form>
  );
}
