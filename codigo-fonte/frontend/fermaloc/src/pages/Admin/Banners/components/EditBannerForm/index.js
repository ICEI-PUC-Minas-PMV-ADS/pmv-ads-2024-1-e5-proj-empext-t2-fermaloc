import { React, useState } from "react";
import { putBanner } from "../../../../../services/bannerService";
import InputImageForm from "../../../../../components/InputImageForm/index.js";

export default function EditBannerForm({ setViewEditForm }) {
  const [image, setImage] = useState(null);

  const submitForm = async (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("image", image);
    await putBanner(formData);
    setImage(null);
    setViewEditForm(false);
    window.location.reload();
  };

  return (
    <form onSubmit={submitForm}>
      <InputImageForm handleImageChange={(e) => setImage(e.target.files[0])} />
      <button type="submit">Enviar</button>
      <button type="button" onClick={() => setViewEditForm(false)}>
        Cancelar
      </button>
    </form>
  );
}
