import React, { useState, useEffect } from "react";
import "./styles.css";
import { useParams } from "react-router-dom";
import { getProductById, getSimalarProducts } from "../../../services/productService";

export default function Product() {
  const { id } = useParams();
  const [product, setProduct] = useState({});
  const [similarProducts, setSimilarProducts] = useState([]);

  useEffect(() => {
    async function fetchProductAndSimilarProducts(id) {
      const productData = await getProductById(id);
      const simiularProductsData = await getSimalarProducts(id, productData.categoryDto.id)
      setProduct(productData);
      console.log(simiularProductsData)
      setSimilarProducts(simiularProductsData)
    }
    fetchProductAndSimilarProducts(id);
  }, [id]);

  return (
    <div>
      {product.name && <h1>{product.name}</h1>}
      <div className="productDetailContainer">
        <img
          src={`data:image/png;base64,${product.image}`}
          alt="Banner"
          className="productDetailImage"
        />
          <p>{product.description}</p>
      </div>
      <div>
        <h1>Outros produtos parecidos</h1>
        <div>
          {similarProducts.length > 0 && similarProducts.map((similarProduct) => {
            <p>{similarProduct.name}</p>
          })}
        </div>
      </div>
    </div>
  );
}
