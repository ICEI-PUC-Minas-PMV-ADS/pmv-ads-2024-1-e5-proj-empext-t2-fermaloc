import { BrowserRouter, Route, Routes } from "react-router-dom";

// Components
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

// Pages
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
import { Children } from "react";
import RoutesAdminComponents from "./pages/Admin/index.js";
import NavBarAdmin from "./components/NavBar_Admin/index.js";

const routesUsers = [
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
] 

const routesAdmin = [
  
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
  {
    id: 10,
    path: "/admin",
    element: <RoutesAdminComponents />,
  },
];

function RoutesComponent() {
  return (
    <BrowserRouter>
      <div style={{ display: 'flex', flexDirection: 'column', height: '100vh', width:'100vw' }}>
        {/* <NavBar/> */}
        <main style={{flex: 1, overflow: 'auto'}}>
          
          {/* <Routes>
            <Route path="/" element={<Layout />}>
              <Route index element={<Home />} />
              <Route path="/about" element={<About />} />
              <Route path="/contact" element={<Contact />} />
            </Route>
          </Routes> */}

          <div>
        
            <Routes>
            {routesAdmin.map((route) => (
                <Route path="/" element={<RoutesAdminComponents />}>
                  <Route
                    key={route.id}
                    index={route.path === "/admin/home"}
                    element={route.element}
                    path={route.path}
                    errorElement={route.errorElement}
                  />
               </Route>
            ))}
            </Routes>
          </div>
          
        </main>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default RoutesComponent;
