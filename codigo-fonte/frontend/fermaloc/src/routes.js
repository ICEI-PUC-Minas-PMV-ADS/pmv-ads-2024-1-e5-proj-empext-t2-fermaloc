import {
    BrowserRouter,
    Route,
    Routes,
    createBrowserRouter,
} from "react-router-dom";

// Components
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

// Pages
import Login from "./pages/Admin/Login/index.js";
import Home from "./pages/User/Home/index.js";
import Product from "./pages/User/Product/index.js";
import Products from "./pages/User/Products/index.js";
import NotFound from "./pages/NotFound/index.js";
import AboutUs from "./pages/User/Aboutus/index.js";

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
        path: "/admin/login",
        element: <Login />,
    },
    {
        path: "/aboutus",
        element: <AboutUs />,
    },
];

function RoutesComponent() {
    return (
        <BrowserRouter>
            <NavBar />
            <main>
                <Routes>
                    {routes.map((route) => (
                        <Route
                            path={route.path}
                            element={route.element}
                            errorElement={route.errorElement}
                        />
                    ))}
                </Routes>
            </main>
            <Footer />
        </BrowserRouter>
    );
}

export default RoutesComponent;
