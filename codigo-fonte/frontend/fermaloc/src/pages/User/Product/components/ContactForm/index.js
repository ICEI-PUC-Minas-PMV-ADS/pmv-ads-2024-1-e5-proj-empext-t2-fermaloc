import React, { useState } from "react";
import InputMask from "react-input-mask";
import styles from "./styles.module.css";
import { makeContact } from "../../../../../services/contactService.js";

export default function ContactForm() {
  const [email, setEmail] = useState("");
  const [phoneNumber1, setPhoneNumber1] = useState("");
  const [phoneNumber2, setPhoneNumber2] = useState("");
  const [message, setMessage] = useState("");
  const [errors, setErrors] = useState({});

  function validateForm() {
    const newErrors = {};
    if (!message) newErrors.message = "A mensagem é obrigatória.";
    if (!email && !phoneNumber1 && !phoneNumber2)
      newErrors.contact =
        "Pelo menos um meio de contato (email, telefone móvel ou telefone fixo) é obrigatório.";
    return newErrors;
  }

  async function submitForm(event) {
    event.preventDefault();
    const formErrors = validateForm();
    if (Object.keys(formErrors).length === 0) {
      setErrors({});
      setEmail("");
      setMessage("");
      setPhoneNumber1("");
      setPhoneNumber2("");
      await makeContact({ message, email, phoneNumber1, phoneNumber2 });
    } else {
      setErrors(formErrors);
    }
  }

  return (
    <form onSubmit={submitForm} className={styles.contactForm}>
      <label>
        Mensagem:
        <textarea
          placeholder="Digite aqui sua mensagem."
          value={message}
          onChange={(e) => setMessage(e.target.value)}
        />
      </label>
      {errors.message && <p className={styles.error}>{errors.message}</p>}

      <label>
        Email:
        <input
          type="email"
          placeholder="Digite aqui seu email para contato"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </label>

      <label>
        Telefone Celular:
        <InputMask
          mask="(99) 99999-9999"
          placeholder="Digite aqui seu telefone celular"
          value={phoneNumber1}
          onChange={(e) => setPhoneNumber1(e.target.value)}
        />
      </label>

      <label>
        Telefone Fixo:
        <InputMask
          mask="(99) 9999-9999"
          placeholder="Digite aqui seu telefone fixo"
          value={phoneNumber2}
          onChange={(e) => setPhoneNumber2(e.target.value)}
        />
      </label>
      {errors.contact && <p className={styles.error}>{errors.contact}</p>}

      <button type="submit">Enviar</button>
    </form>
  );
}
