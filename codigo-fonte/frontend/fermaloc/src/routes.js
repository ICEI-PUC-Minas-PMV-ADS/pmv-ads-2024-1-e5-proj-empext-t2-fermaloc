import { BrowserRouter, Route, Routes } from "react-router-dom";

import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

import Login from "./pages/Admin/Login/index.js";
import LonginEsqueciSenha from "./pages/Admin/Login/forgot-password.js";
import Home from "./pages/User/Home/index.js";
import Product from "./pages/User/Product/index.js";
import Products from "./pages/User/Products/index.js";
import NotFound from "./pages/NotFound/index.js";
import AboutUs from "./pages/User/Aboutus/index.js";
import HomeAdmin from "./pages/Admin/Home/index.js";
import CategoriesAdmin from "./pages/Admin/Categories/index.js";
import BannersAdmin from "./pages/Admin/Banners/index.js";
import ProductsAdmin from "./pages/Admin/Products/index.js";

const routes = [
    {
        path: "/",
        element: <Home />,
        errorElement: <NotFound />,
    },
    {
        path: "/produtos",
        element: <Products />,
    },
    {
        path: "/produtos/:id",
        element: <Product />,
    },
    {
        path: "/aboutus",
        element: <AboutUs />,
    },
    {
        path: "/login",
        element: <Login />,
    },
    {
        path: "/login/esqueci-senha",
        element: <LonginEsqueciSenha />,
    },
    {
        path: "/admin/home",
        element: <HomeAdmin />,
    },
    {
        path: "/admin/categorias",
        element: <CategoriesAdmin />,
    },
    {
        path: "/admin/produtos",
        element: <ProductsAdmin />,
    },
    {
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

                <main
                    style={{ flex: "1 0 auto", margin: "100px 40px 80px 40px" }}
                >
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
