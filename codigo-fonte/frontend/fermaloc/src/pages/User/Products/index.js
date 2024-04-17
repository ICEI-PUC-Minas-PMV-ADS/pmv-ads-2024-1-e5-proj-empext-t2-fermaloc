import { React, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FaAngleRight } from "react-icons/fa6";

// Estilização
import styles from "./styles.module.css";

// Services
import {
  getProducts,
  getProductByStatusAndCategory,
} from "../../../services/productService.js";
import { getActiveCategories } from "../../../services/categoryService.js";

// Components
import Product from "./components/Product/index.js";

export default function Products() {
  const [products, setProducts] = useState([{}]);
  const [categories, setCategories] = useState([{}]);

  useEffect(() => {
    async function fetchProductsAndCategories() {
      const productsData = await getProducts();
      const categoriesData = await getActiveCategories();
      setProducts(productsData);
      setCategories(categoriesData);
    }

    fetchProductsAndCategories();
  }, []);

  async function filterProductsByCategory(categoryId) {
    const productsData = await getProductByStatusAndCategory(true, categoryId);
    setProducts(productsData);
    console.log(productsData);
  }

  return (
    <div className={styles.page}>
      <aside className={styles.filters}>
        <p>Categorias:</p>
        <ul>
          {categories.map((category) => {
            return (
              <li
                onClick={() => filterProductsByCategory(category.id)}
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
        {products.map((product) => {
          return (
            <Link
              to={`${product.id}`}
              key={product.id}
              style={{
                textDecoration: "none",
                color: "black",
              }}
            >
              <Product
                image={product.image}
                id={product.id}
                name={product.name}
              />
            </Link>
          );
        })}
      </div>
    </div>
  );
}
