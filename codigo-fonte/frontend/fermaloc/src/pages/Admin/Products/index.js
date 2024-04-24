import { React, useEffect, useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";
import { getProductByStatus } from "../../../services/productService.js";
import Product from "./components/Product/index.js";
import NewProductForm from "./components/NewProductForm/index.js";
import FilterStatus from "../../../components/FilterStatus/index.js";

export default function ProductsAdmin() {
  const [products, setProducts] = useState([]);
  const { authenticated } = useAuthentication();


  useEffect(() => {
    async function fetchCategories() {
      const productsData = await getProductByStatus();
      setProducts(productsData);
    }
    fetchCategories();
  }, []);

  async function handleFilter(status){
    const productsData = await getProductByStatus(status);
    setProducts(productsData);
  }

  return (
    authenticated && (
      <div>
        <div>
          <h1>Produtos</h1>
          <FilterStatus handleFilter={handleFilter}/>
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
