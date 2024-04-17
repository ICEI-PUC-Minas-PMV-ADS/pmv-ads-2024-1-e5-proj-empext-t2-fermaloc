import React from 'react'

export default function InputImageForm({handleImageChange}) {
  return (
    <input type='file' onChange={handleImageChange} accept="image/*" />
  )
}
