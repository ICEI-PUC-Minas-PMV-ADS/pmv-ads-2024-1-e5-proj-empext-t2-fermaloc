import React, { useState, useEffect } from "react";
import "./styles.css";
import { getBannerById } from "../../../services/bannerService.js";
import { getTopProducts } from "../../../services/productService.js";
import TopProduct from "./components/TopProduct/index.js";
import { useLocation } from "react-router-dom";
import NavBar from "../../../components/NavBar/index.js";
import Footer from "../../../components/Footer/index.js";
import makita from "../../../assets/imgs/makitalogo.jpg";
import dewalt from "../../../assets/imgs/logodewalt.png";
import bosch from "../../../assets/imgs/boschlogo.png";


export default function Home() {
  const [banner, setBanner] = useState(null);
  const [topProducts, setTopProducts] = useState([]);

  useEffect(() => {
    async function fetchBanner(id) {
      const bannerData = await getBannerById(id);
      setBanner(bannerData.image);
    }

    async function fetchTopProducts() {
      const topProductsData = await getTopProducts();
      console.log(topProductsData);
      setTopProducts(topProductsData.slice(0, 3));
    }

    //tera que remover esse id posteriormente, temos que ver uma melhor forma de deifnir qual banner ira ficar na home, talvez mais um endpont para que o admin escolha.
    //FAVOR NÃO MUDAR A ID
    const id = "08dc4eb0-fa0f-40e7-82f1-7e82cca58ef9";
    fetchBanner(id);
    fetchTopProducts();
  }, []);

  const location = useLocation();

  return (
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div className="container">
        <div className="bannerContainer">
          <img
            src={`data:image/png;base64,${banner}`}
            alt="Banner"
            className="imgBanner"
          />
        </div>
        <div>
          <h1 className="us">Parceiros</h1>
          <div className="logopartners">
            <img src={makita} alt="logo" />
            <img src={dewalt} alt="logo" />
            <img src={bosch} alt="logo" />
          </div>
        </div>
        <div className="topProductsContainer">
          <h1>Principais produtos</h1>
          <div className="topProductsComponentsContainer">
            {topProducts.map((product) => {
              return (
                <TopProduct
                  name={product.name}
                  image={product.image}
                  id={product.id}
                />
              );
            })}
          </div>
        </div>
      </div>
      {location.pathname !== "/admin/login" && <Footer />}
    </>
  );
}
