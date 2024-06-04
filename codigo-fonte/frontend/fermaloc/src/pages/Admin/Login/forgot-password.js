import React from "react";
import { useState } from "react";
import { MdEmail, MdContentCopy } from "react-icons/md";
import { Link } from "react-router-dom";

// Imagens
import logo from "../../../assets/imgs/logofer.jpg";

// Hooks
import useAuthentication from "../../../hooks/useAuthentication";

// CSS
import styles from "./styles.module.css";

export default function LoginForgotPassword() {
    const [email, setEmail] = useState("");
    const [newPassword, setNewPassword] = useState("");

    const { resetPassword } = useAuthentication();

    async function submitForm(e) {
        e.preventDefault();

        const result = await resetPassword(email);

        setNewPassword(result);
    }

    const newPasswordAlert = (password) => {
        if (password.trim().length === 0) {
            return null;
        }

        return (
            <div className={styles.passwordAlert}>
                <div />
                <span>Nova senha é {password}</span>
                <button
                    type="button"
                    onClick={() => {
                        navigator.clipboard.writeText(newPassword);

                        alert("Senha copiada");
                    }}
                >
                    <MdContentCopy className={styles.icon} />
                </button>
            </div>
        );
    };

    return (
        <div className={styles.page}>
            <div className={styles.wrapper}>
                <form action="">
                    <div className={styles.logologin}>
                        <img src={logo} alt="logo" />
                    </div>
                    <h1>Esqueci Minha Senha</h1>
                    <div className={styles.inputBox}>
                        <input
                            type="text"
                            placeholder="Email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                        <MdEmail className={styles.icon} />
                    </div>
                    {newPasswordAlert(newPassword)}
                    <button type="submit" onClick={(e) => submitForm(e)}>
                        Resetar
                    </button>
                    <div className={styles.acessoHome}>
                        <p>
                            Ir para
                            <Link to="/"> tela inicial</Link>
                        </p>
                    </div>
                </form>
            </div>
        </div>
    );
}
