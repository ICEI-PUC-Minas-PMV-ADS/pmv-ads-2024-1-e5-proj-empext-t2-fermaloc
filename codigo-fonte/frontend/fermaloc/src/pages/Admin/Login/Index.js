import React from 'react';
import { useState } from 'react';
import { login } from '../../../services/authenticationService.js';
import "./Styles.css";

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
    <div>
        {/* Código HTML */}
        <form>
          <input className='' type="text" name="email" value={email} 
          onChange={(e) => setEmail(e.target.value)}
          />
          <input className='' type="password" name="password" value={password} 
          onChange={(e) => setPassword(e.target.value)}
          />
          <button className='' type="submit" onClick={(e) => submitForm(e)}>Login</button>
        </form>
    </div>
  )
}

// CSS

// .nome da classe
