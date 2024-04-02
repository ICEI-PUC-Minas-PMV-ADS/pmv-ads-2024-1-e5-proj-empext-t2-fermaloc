import React, { useState, useEffect } from "react";
import "./styles.css";
import { useParams, useLocation } from "react-router-dom";
import {
  getProductById,
  getSimalarProducts,
} from "../../../services/productService";
import NavBar from "../../../components/NavBar/index.js";
import Footer from "../../../components/Footer/index.js";
import SimilarProduct from "./components/SimilarProduct/index.js";
import { FaWhatsapp } from "react-icons/fa";

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

  const location = useLocation();
  return (
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div className="pageContainer">
        {product.name && <h1>{product.name}</h1>}
        <div className="productDetailContainer">
            <p className="description">{product.description}</p>
          <img
            src={`data:image/png;base64,${product.image}`}
            alt="Banner"
            className="productDetailImage"
          />
        </div>

        <div className="contactContainer">
              <h3>
                ENTRE EM CONTATO COM UM DE NOSSOS VENDEDORES E SOLICITE UM
                ORÇAMENTO!
              </h3>
              <button>
                <FaWhatsapp style={{ fontSize: 40, color: "#00e676" }} />
              </button>
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
      {location.pathname !== "/admin/login" && <Footer />}
    </>
  );
}
