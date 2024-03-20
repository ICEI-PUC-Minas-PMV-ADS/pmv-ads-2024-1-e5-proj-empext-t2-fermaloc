// RENOMEAR A PÁGINA APP.JS DEPOIS PARA ROUTER.JS
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Login from "./pages/Admin/Login/index.js";
import Home from "./pages/User/Home/index.js";
import Product from "./pages/User/Product/index.js";
import Products from "./pages/User/Products/index.js";
import NavBar from "./components/NavBar/index.js";
import Footer from "./components/Footer/index.js";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
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
    path: "/admin/login",
    element: <Login />,
  },
]);

function Routes() {
  return (
    <>
      <NavBar />
      <RouterProvider router={router} />
      <Footer />
    </>
  );
}

export default Routes;
