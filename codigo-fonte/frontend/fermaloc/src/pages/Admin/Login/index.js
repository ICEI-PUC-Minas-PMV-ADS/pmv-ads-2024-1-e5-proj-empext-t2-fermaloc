import React from "react";
import { useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";
import { MdEmail, MdLock } from "react-icons/md";
import logo from "../../../assets/imgs/logofer.jpg";
import { Link } from "react-router-dom";

export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const { login } = useAuthentication();

    async function submitForm(e) {
        e.preventDefault();
        const loginDto = {
            email,
            password,
        };
        await login(loginDto);
    }
    return (
        <div className={styles.page}>
            {/* Código HTML */}
            <div className={styles.wrapper}>
                <form action="">
                    <div className={styles.logologin}>
                        <img src={logo} alt="logo" />
                    </div>
                    <h1>Login</h1>

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

                    <div className={styles.inputBox}>
                        <input
                            type="password"
                            placeholder="Password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                        <MdLock className={styles.icon} />
                    </div>

                    <div className={styles.rememberForgot}>
                        <label>
                            <input type="checkbox" name="remember" /> Lembre-me
                        </label>
                        <Link to="/login/esqueci-senha">Esqueceu a senha?</Link>
                    </div>

                    <button
                        className=""
                        type="submit"
                        onClick={(e) => submitForm(e)}
                    >
                        Login
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

// CSS

// .nome da classe
