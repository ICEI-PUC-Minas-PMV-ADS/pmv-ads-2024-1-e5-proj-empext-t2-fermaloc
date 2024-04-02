import { React, useState, useEffect } from "react";
import "./styles.css";
import { Link, useLocation } from "react-router-dom";
import NavBar from "../../../components/NavBar/index.js";
import Footer from "../../../components/Footer/index.js";
import {
  getProducts,
  getProductByStatusAndCategory,
  getProductBySearchedName,
} from "../../../services/productService.js";
import { getCategories } from "../../../services/categoryService.js";
import Product from "./components/Product/index.js";
import { IoSearchOutline } from "react-icons/io5";
import { getBannerById } from "../../../services/bannerService.js";

export default function Products() {
  const [products, setProducts] = useState([{}]);
  const [categories, setCategories] = useState([{}]);
  const [filterInput, setFilterInput] = useState("");
  const [banner, setBanner] = useState(null);

  const location = useLocation();

  useEffect(() => {
    async function fetchBanner(id) {
      const bannerData = await getBannerById(id);
      setBanner(bannerData.image);
    }
    async function fetchProductsAndCategories() {
      const productsData = await getProducts();
      const categoriesData = await getCategories();
      setProducts(productsData);
      setCategories(categoriesData);
    }

    //tera que remover esse id posteriormente, temos que ver uma melhor forma de deifnir qual banner ira ficar na home, talvez mais um endpont para que o admin escolha.
    //FAVOR NÃO MUDAR A ID
    const id = "08dc4eb0-fa0f-40e7-82f1-7e82cca58ef9";
    fetchBanner(id);
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
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div className="pageContainer">
        <div className="bannerContainer">
          <img
            src={`data:image/png;base64,${banner}`}
            alt="Banner"
            className="imgBanner"
          />
        </div>
        <div className="productsAndFiltersContainer">
          <aside className="filters">
            <div className="filterInput">
              <input onChange={(e) => setFilterInput(e.target.value)} placeholder="Pesquisa"/>
              <button onClick={() => filterProductsByName(filterInput)}>
                <IoSearchOutline />
              </button>
            </div>
            <div>
              <p>Categorias:</p>
              <ul>
                {categories.map((category) => {
                  return (
                    <li
                      onClick={() => filterProductsByCategory(category.id)}
                      style={{ cursor: "pointer" }}
                    >
                      - {category.name}
                    </li>
                  );
                })}
              </ul>
            </div>
          </aside>
          <div className="products">
            {products.map((product) => {
              return (
                <Link
                  to={`${product.id}`}
                  key={product.id}
                  style={{ textDecoration: "none", color: "black" }}
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
      </div>
      {location.pathname !== "/admin/login" && <Footer />}
    </>
  );
}
