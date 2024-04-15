import { RouterProvider, createBrowserRouter } from "react-router-dom";
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

const router = createBrowserRouter([
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
]);

function Routes() {
  return <RouterProvider router={router} />;
}

export default Routes;
