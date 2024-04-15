import React, { useState, useEffect } from "react";
import { useParams, useLocation } from "react-router-dom";

// Estilização
import "./styles.css";

// Serviço
import {
    getProductById,
    getSimalarProducts,
} from "../../../services/productService";

// Components
import SimilarProduct from "./components/SimilarProduct/index.js";
import Title from "../../../components/Title/index.js";

export default function Product() {
    const { id } = useParams();
    const [product, setProduct] = useState({});
    const [similarProducts, setSimilarProducts] = useState([]);

    useEffect(() => {
        async function fetchProductAndSimilarProducts(id) {
            const productData = await getProductById(id);
            const simiularProductsData = await getSimalarProducts(
                id,
                productData.categoryDto.id
            );
            setProduct(productData);
            console.log(simiularProductsData);
            setSimilarProducts(simiularProductsData);
        }
        fetchProductAndSimilarProducts(id);
    }, [id]);

    return (
        <>
            <div className="pageContainer">
                {product.name && <Title title={product.name}></Title>}
                <div className="productDetailContainer">
                    <img
                        src={`data:image/png;base64,${product.image}`}
                        alt="Banner"
                        className="productDetailImage"
                    />
                    <div className="description">
                        <div className="descriptionText">
                            {product.description}
                        </div>
                        <div className="descriptionBackground" />
                    </div>
                </div>
                <div className="similarProductsContainer">
                    <h1>Outros produtos parecidos</h1>
                    <div className="similarProductsImageContainer">
                        {similarProducts.length > 0 ? (
                            similarProducts.map((similarProduct) => {
                                return (
                                    <SimilarProduct
                                        image={similarProduct.image}
                                        id={similarProduct.id}
                                    />
                                );
                            })
                        ) : (
                            <h3>Nenhum produto similar encontrado!</h3>
                        )}
                    </div>
                </div>
            </div>
        </>
    );
}
