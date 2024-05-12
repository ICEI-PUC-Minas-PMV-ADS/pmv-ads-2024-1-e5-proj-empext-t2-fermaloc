import { BrowserRouter, Route, Routes } from "react-router-dom";

import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

import Login from "./pages/Admin/Login/index.js";
import Home from "./pages/User/Home/index.js";
import Product from "./pages/User/Product/index.js";
import Products from "./pages/User/Products/index.js";
import NotFound from "./pages/NotFound/index.js";
import AboutUs from "./pages/User/AboutUs/index.js";
import HomeAdmin from "./pages/Admin/Home/index.js";
import CategoriesAdmin from "./pages/Admin/Categories/index.js";
import BannersAdmin from "./pages/Admin/Banners/index.js";
import ProductsAdmin from "./pages/Admin/Products/index.js";

const routes = [
  {
    id: 1,
    path: "/",
    element: <Home />,
    errorElement: <NotFound />,
  },
  {
    id: 2,
    path: "/produtos",
    element: <Products />,
  },
  {
    id: 3,
    path: "/produtos/:id",
    element: <Product />,
  },
  {
    id: 4,
    path: "/aboutus",
    element: <AboutUs />,
  },
  {
    id: 5,
    path: "/login",
    element: <Login />,
  },
  {
    id: 6,
    path: "/admin/home",
    element: <HomeAdmin />,
  },
  {
    id: 7,
    path: "/admin/categorias",
    element: <CategoriesAdmin />,
  },
  {
    id: 8,
    path: "/admin/produtos",
    element: <ProductsAdmin />,
  },
  {
    id: 9,
    path: "/admin/banners",
    element: <BannersAdmin />,
  },
];

function RoutesComponent() {
  return (
    <BrowserRouter>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          height: "100vh",
          
        }}
      >
        <NavBar />
       
        <main style={{ flex: "1 0 auto", margin: "100px 40px 80px 40px"}}>
          <Routes>
            {routes.map((route) => (
              <Route
                key={route.id}
                path={route.path}
                element={route.element}
                errorElement={route.errorElement}
              />
            ))}
          </Routes>
        </main>

        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default RoutesComponent;
