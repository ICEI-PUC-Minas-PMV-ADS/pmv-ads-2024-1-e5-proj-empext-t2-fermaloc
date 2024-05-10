import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

// Estilização
import styles from "./styles.module.css";

// Imagens
import makita from "../../../assets/imgs/logos/makita.png";
import dewalt from "../../../assets/imgs/logos/dewalt.png";
import bosch from "../../../assets/imgs/logos/bosch.png";

// Serviços
import { getTopProducts } from "../../../services/productService.js";
import { getBanner } from "../../../services/bannerService.js";

// Componentes
import TopProduct from "./components/TopProduct/index.js";
import Title from "../../../components/Title/index.js";

export default function Home() {
  const [topProducts, setTopProducts] = useState([]);
  const [banner, setBanner] = useState(null);

  useEffect(() => {
    async function fetchTopProductsAndBanner() {
      const topProductsData = await getTopProducts();
      const bannerData = await getBanner();
      setBanner(bannerData.image);
      console.log(topProductsData);
      setTopProducts(topProductsData.slice(0, 3));
    }

    fetchTopProductsAndBanner();
  }, []);

  return (
    <div className={styles.page}>
      <div className={styles.bannerContainer}>
        <img
          src={`data:image/png;base64,${banner}`}
          alt="Banner"
          className={styles.imgBanner}
        />
      </div>

      <div className={styles.container}>
        <div className={styles.topProductsContainer}>
          <Title title="Principais Produtos" />
          <div className={styles.topProductsComponentsContainer}>
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
      <div className={styles.partnersContainer}>
        <Title title="Parceiros" />
        <div className={styles.logoPartners}>
          <div className={styles.logoPartner}>
            <img src={makita} alt="Logo Makita" />
          </div>
          <div className={styles.logoPartner}>
            <img src={dewalt} alt="Logo DeWalt" />
          </div>
          <div className={styles.logoPartner}>
            <img src={bosch} alt="Logo Bosch" />
          </div>
        </div>
      </div>
    </div>
  );
}
