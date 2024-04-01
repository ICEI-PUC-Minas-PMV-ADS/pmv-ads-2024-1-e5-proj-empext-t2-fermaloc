import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Login from "./pages/Admin/Login/index.js";
import Home from "./pages/User/Home/index.js";
import Product from "./pages/User/Product/index.js";
import Products from "./pages/User/Products/index.js";
import NotFound from "./pages/NotFound/index.js";
import AboutUs from "./pages/User/Aboutus/index.js";


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
    path: "/admin/login",
    element: <Login />,
  },
  {
    path: "/aboutus",
    element: <AboutUs/>,
  },
]);

function Routes() {
  return (
    <>
      <RouterProvider router={router} />
    </>
  );
}

export default Routes;
