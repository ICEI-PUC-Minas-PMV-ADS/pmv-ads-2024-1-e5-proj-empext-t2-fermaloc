import React from 'react'
import "./styles.css"
import logonavbar from "../../assets/imgs/logonavbar.png";

export default function NavBar() {
  return (
    <div className='general'>
      
    <div className='navlogo'>
    <img src={logonavbar} alt="logo"/>
    </div>
    <ul><li>home</li><li>produtos</li><li>Quem Somos</li></ul>
    </div>
  )
}
