import { React, useEffect, useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";
import {
  getProductByStatus,
  getProductByStatusAndCategory,
} from "../../../services/productService.js";
import { getCategories } from "../../../services/categoryService.js";
import Product from "./components/Product/index.js";
import NewProductForm from "./components/NewProductForm/index.js";
import FilterStatus from "../../../components/FilterStatus/index.js";
import { FaAngleRight } from "react-icons/fa6";

export default function ProductsAdmin() {
  const [products, setProducts] = useState([]);
  const { authenticated } = useAuthentication();
  const [categories, setCategories] = useState([{}]);
  const [status, setStatus] = useState(true);

  useEffect(() => {
    async function fetchProductsAndCategories() {
      const productsData = await getProductByStatus();
      const categoriesData = await getCategories();
      setCategories(categoriesData);
      setProducts(productsData);
    }
    fetchProductsAndCategories();
  }, []);

  async function handleFilterStatus(status) {
    const productsData = await getProductByStatus(status);
    setProducts(productsData);
  }

  async function handleFilterCategory(categoryId) {
    const productsData = await getProductByStatusAndCategory(
      status,
      categoryId
    );
    setProducts(productsData);
  }

  return (
    authenticated && (
      <div className={styles.page}>
        <h1>Produtos</h1>
        <FilterStatus
          handleFilter={handleFilterStatus}
          status={status}
          setStatus={setStatus}
        />
        <div className={styles.categoriesAndProductsContainer}>
          <aside>
            <ul>
              {categories.map((category) => {
                return (
                  <li
                    onClick={() => handleFilterCategory(category.id)}
                    style={{ cursor: "pointer" }}
                  >
                    {category.name}
                    <FaAngleRight />
                  </li>
                );
              })}
            </ul>
          </aside>
          <div className={styles.products}>
            {products.length > 0 ? (
              products.map((product) => {
                return <Product key={product.id} product={product} />;
              })
            ) : (
              <p>Nenhum produto cadastrado</p>
            )}
          </div>
        </div>

        <div>
          <NewProductForm />
        </div>
      </div>
    )
  );
}
