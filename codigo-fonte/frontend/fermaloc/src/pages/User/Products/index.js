import { React, useState, useEffect } from "react";
import { FaAngleRight } from "react-icons/fa6";
import { IoSearchOutline } from "react-icons/io5";

// Estilização
import styles from "./styles.module.css";

// Services
import {
  getProductByStatus,
  getProductByStatusAndCategory,
  getProductBySearchedName,
} from "../../../services/productService.js";
import { getCategoriesByStatus } from "../../../services/categoryService.js";

// Components
import Product from "./components/Product/index.js";

export default function Products() {
  const [products, setProducts] = useState([{}]);
  const [categories, setCategories] = useState([{}]);
  const [filterInput, setFilterInput] = useState(" ");

  useEffect(() => {
    async function fetchProductsAndCategories() {
      const productsData = await getProductByStatus();
      const categoriesData = await getCategoriesByStatus();
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

  async function filterProductsByName(name) {
    const productsData = await getProductBySearchedName(name);
    setProducts(productsData);
    setFilterInput("");
  }

  return (
    <div className={styles.page}>
      <aside className={styles.filters}>
        <div className={styles.filterInput}>
          <input
            value={filterInput}
            onChange={(e) => setFilterInput(e.target.value)}
            placeholder="Pesquisa"
          />
          <button onClick={() => filterProductsByName(filterInput)}>
            <IoSearchOutline />
          </button>
        </div>
        <h1>Categorias:</h1>
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
          <li
            onClick={() => filterProductsByName("")}
            style={{ cursor: "pointer" }}
          >
            <strong>Todos os Produtos</strong>
            <FaAngleRight />
          </li>
        </ul>
      </aside>
      <div className={styles.products}>
        {products.map((product) => {
          return (
            <Product
              image={product.image}
              id={product.id}
              name={product.name}
            />
          );
        })}
      </div>
    </div>
  );
}
