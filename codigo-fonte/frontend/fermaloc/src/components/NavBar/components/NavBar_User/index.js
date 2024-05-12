import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";

// Estilização
import styles from "./styles.module.css";

// Serviço
import { getBanner } from "../../../../services/bannerService.js";

export default function NavBar_User({ location, logonavbar }) {
  //   const [banner, setBanner] = useState(null);

  //   useEffect(() => {
  //     async function fetchBanner() {
  //       const bannerData = await getBanner();
  //       setBanner(bannerData.image);
  //     }
  //     fetchBanner();
  //   }, []);

  //   return (
  //   <header>
  //     <nav
  //       style={
  //         location.pathname.trim() === "/" ||
  //         location.pathname.trim() === "/produtos"
  //           ? { marginBottom: "25vh" }
  //           : { height: "25vh" }
  //       }
  //     >
  //       <Link to="/" className={styles.navlogo}>
  //         <img src={logonavbar} alt="logo" />
  //       </Link>
  //       {location.pathname.trim()==="/"|| location.pathname.trim()==="/aboutus"?undefined:<div className={styles.navSearch}>
  //         <div className={styles.navSearchInput}>
  //           <div />
  //           <input type="text" />
  //         </div>
  //         <button>
  //           <div />
  //           <svg
  //             viewBox="0 0 32 32"
  //             version="1.1"
  //             xmlns="http://www.w3.org/2000/svg"
  //           >
  //             <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
  //               <g transform="translate(-256.000000, -1139.000000)">
  //                 <path d="M269.46,1163.45 C263.17,1163.45 258.071,1158.44 258.071,1152.25 C258.071,1146.06 263.17,1141.04 269.46,1141.04 C275.75,1141.04 280.85,1146.06 280.85,1152.25 C280.85,1158.44 275.75,1163.45 269.46,1163.45 L269.46,1163.45 Z M287.688,1169.25 L279.429,1161.12 C281.591,1158.77 282.92,1155.67 282.92,1152.25 C282.92,1144.93 276.894,1139 269.46,1139 C262.026,1139 256,1144.93 256,1152.25 C256,1159.56 262.026,1165.49 269.46,1165.49 C272.672,1165.49 275.618,1164.38 277.932,1162.53 L286.224,1170.69 C286.629,1171.09 287.284,1171.09 287.688,1170.69 C288.093,1170.3 288.093,1169.65 287.688,1169.25 L287.688,1169.25 Z"></path>
  //               </g>
  //             </g>
  //           </svg>
  //         </button>
  //       </div>}
  //       <ul>
  //         <li className={styles.navLink}>
  //           <Link to="/produtos">
  //             <div />
  //             <p>Produtos</p>
  //           </Link>
  //         </li>
  //         <li className={styles.navLink}>
  //           <Link to="/aboutus">
  //             <div />
  //             <p>Quem Somos</p>
  //           </Link>
  //         </li>
  //       </ul>
  //     </nav>

  //   </header>
  // )

  return (
    <>
      <div className={styles.navlogo}>
        <Link to="/">
          <img src={logonavbar} alt="logo" />
        </Link>
      </div>
      <ul>
        <li>
          <Link to="/" style={{ textDecoration: "none", color: "white" }}>
            <p>Home</p>
          </Link>
        </li>
        <li>
          <Link
            to="/produtos"
            style={{ textDecoration: "none", color: "white" }}
          >
            <p>Produtos</p>
          </Link>
        </li>
        <li>
          <Link
            to="/aboutus"
            style={{ textDecoration: "none", color: "white" }}
          >
            <p>Quem Somos</p>
          </Link>
        </li>
      </ul>
    </>
  );
}
