import React from 'react'
import "./styles.css";
import { useParams } from 'react-router-dom';

export default function Product() {
  const {id} = useParams()

  return (
    <div>Product</div>
  )
}
