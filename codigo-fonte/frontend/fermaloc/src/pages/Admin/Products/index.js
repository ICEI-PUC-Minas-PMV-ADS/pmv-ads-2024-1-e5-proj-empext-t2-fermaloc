import { React, useEffect, useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";
import { getProducts } from "../../../services/productService.js";
import Product from "./components/Product/index.js";
import NewProductForm from "./components/NewProductForm/index.js";

export default function ProductsAdmin() {
  const [products, setProducts] = useState([]);
  const { authenticated } = useAuthentication();


  useEffect(() => {
    async function fetchCategories() {
      const productsData = await getProducts();
      setProducts(productsData);
    }
    fetchCategories();
  }, []);

  return (
    authenticated && (
      <div>
        <div>
          <h1>Produtos</h1>
          {products.length > 0 ? (
            products.map((product) => {
              return <Product key={product.id} product={product} />;
            })
          ) : (
            <p>Nenhum produto cadastrado</p>
          )}
        </div>
        <div>
          <NewProductForm />
        </div>
      </div>
    )
  );
}
