import React, { useState, useEffect } from "react";
import { Link, useLocation } from "react-router-dom";

// Estilização
import "./styles.css";

// Imagens
import makita from "../../../assets/imgs/logos/makita.png";
import dewalt from "../../../assets/imgs/logos/dewalt.png";
import bosch from "../../../assets/imgs/logos/bosch.png";

// Serviços
import { getTopProducts } from "../../../services/productService.js";

// Componentes
import TopProduct from "./components/TopProduct/index.js";
import Title from "../../../components/Title/index.js";

export default function Home() {
    const [topProducts, setTopProducts] = useState([]);

    useEffect(() => {
        async function fetchTopProducts() {
            const topProductsData = await getTopProducts();
            console.log(topProductsData);
            setTopProducts(topProductsData.slice(0, 3));
        }

        fetchTopProducts();
    }, []);

    return (
        <>
            <div className="container">
                <div className="topProductsContainer">
                    <Title title="Principais Produtos" />
                    <div className="topProductsComponentsContainer">
                        {topProducts.map((product) => {
                            return (
                                <TopProduct
                                    name={product.name}
                                    image={product.image}
                                    id={product.id}
                                    key={product.id}
                                />
                            );
                        })}
                    </div>
                    <Link
                        to="/produtos"
                        style={{ textDecoration: "underline", color: "black" }}
                    >
                        Ver Mais
                    </Link>
                </div>
            </div>
            <div className="partnersContainer">
                <Title title="Parceiros" />
                <div className="logoPartners">
                    <div className="logoPartner">
                        <img src={makita} alt="Logo Makita" />
                    </div>
                    <div className="logoPartner">
                        <img src={dewalt} alt="Logo DeWalt" />
                    </div>
                    <div className="logoPartner">
                        <img src={bosch} alt="Logo Bosch" />
                    </div>
                </div>
            </div>
        </>
    );
}
