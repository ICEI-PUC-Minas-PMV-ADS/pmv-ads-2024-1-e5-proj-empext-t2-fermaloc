import { BrowserRouter, Outlet, Route, Routes } from "react-router-dom";


// Components
import Footer from "../../components/Footer";
import NavBarAdmin from "../../components/NavBar_Admin";
import HomeAdmin from "./Home";
import { Children } from "react";
import BannersAdmin from "./Banners";

// Pages
// import Login from "./pages/Admin/Login/index.js";
// import Home from "./pages/User/Home/index.js";
// import Product from "./pages/User/Product/index.js";
// import Products from "./pages/User/Products/index.js";
// import NotFound from "./pages/NotFound/index.js";
// import AboutUs from "./pages/User/AboutUs/index.js";
// import HomeAdmin from "./pages/Admin/Home/index.js";
// import CategoriesAdmin from "./pages/Admin/Categories/index.js";
// import BannersAdmin from "./pages/Admin/Banners/index.js";
// import ProductsAdmin from "./pages/Admin/Products/index.js";
// import { Children } from "react";
// import NavBarAdmin from "../../components/NavBar_Admin/index.js";

// const routes = [
  
  
//   {
//     id: 5,
//     path: "/login",
//     element: <Login />,
//   },
//   {
//     id: 6,
//     path: "/admin/home",
//     element: <HomeAdmin />,
//   },
//   {
//     id: 7,
//     path: "/admin/categorias",
//     element: <CategoriesAdmin />,
//   },
//   {
//     id: 8,
//     path: "/admin/produtos",
//     element: <ProductsAdmin />,
//   },
//   {
//     id: 9,
//     path: "/admin/banners",
//     element: <BannersAdmin />,
//   },
// ];

function RoutesAdminComponents() {
  return (
    
    // <BrowserRouter>
      <div style={{ display: 'flex', flexDirection: 'column', height: '100vh', width:'100vw' }}>
        <NavBarAdmin />
        <main style={{flex: 1, overflow: 'auto'}}>
            <HomeAdmin />
            {/* <BannersAdmin /> */}
        <Outlet />   
        </main>
        <Footer />
      </div>
    // </BrowserRouter>
  );
}

export default RoutesAdminComponents;
