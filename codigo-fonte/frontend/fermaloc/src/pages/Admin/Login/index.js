import React from 'react';
import { useState } from 'react';
import { login } from '../../../services/authenticationService.js';
import "./styles.css";
import { MdEmail, MdLock } from "react-icons/md";
import logo from "../../../assets/imgs/logofer.jpg";
import { Link } from "react-router-dom";


export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    

    async function submitForm(e) {
      e.preventDefault();
      const loginDto = {
        email,
        password,
      };
      await login(loginDto);
    }
  return (

    <div >
        {/* Código HTML */}
          <div className="wrapper">
            <form action="">

             <div className='logologin'>
             <img src={logo} alt="logo"/>
            </div>
              <h1>Login</h1>

              <div className="input-box">
                <input type="text" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} 
                required/>
                <MdEmail className="icon" />
              </div>

              <div className="input-box">
                <input type="password" placeholder="Password" value={password} 
                onChange={(e) => setPassword(e.target.value)}
                required/>
                <MdLock className="icon" />
              </div>

              <div className="remember-forgot">
                <label>
                  <input type="checkbox" name="remember" /> Lembre-me
                </label>
                <a href="#">Esqueceu a senha?</a>
              </div>

              <button className='' type="submit" onClick={(e) => submitForm(e)}>Login</button>

              <div className="acesso-home">

                <p>
                  Ir para 
                  <Link to="/"> tela inicial</Link></p>
                
              </div>

            </form>
          </div>   
    </div>
  )
}

// CSS

// .nome da classe
