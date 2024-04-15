import { React, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { IoSearchOutline } from "react-icons/io5";

// Estilização
import "./styles.css";

// Services
import {
    getProducts,
    getProductByStatusAndCategory,
    getProductBySearchedName,
} from "../../../services/productService.js";
import { getCategories } from "../../../services/categoryService.js";

// Components
import Product from "./components/Product/index.js";

export default function Products() {
    const [products, setProducts] = useState([{}]);
    const [categories, setCategories] = useState([{}]);
    const [filterInput, setFilterInput] = useState("");

    useEffect(() => {
        async function fetchProductsAndCategories() {
            const productsData = await getProducts();
            const categoriesData = await getCategories();
            setProducts(productsData);
            setCategories(categoriesData);
        }

        fetchProductsAndCategories();
    }, []);

    async function filterProductsByCategory(categoryId) {
        const productsData = await getProductByStatusAndCategory(
            true,
            categoryId
        );
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
            <div className="pageContainer">
                <div className="productsAndFiltersContainer">
                    <aside className="filters">
                        <div className="filterInput">
                            <input
                                onChange={(e) => setFilterInput(e.target.value)}
                                placeholder="Pesquisa"
                            />
                            <button
                                onClick={() =>
                                    filterProductsByName(filterInput)
                                }
                            >
                                <IoSearchOutline />
                            </button>
                        </div>
                        <div>
                            <p>Categorias:</p>
                            <ul>
                                {categories.map((category) => {
                                    return (
                                        <li
                                            onClick={() =>
                                                filterProductsByCategory(
                                                    category.id
                                                )
                                            }
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
            </div>
        </>
    );
}
