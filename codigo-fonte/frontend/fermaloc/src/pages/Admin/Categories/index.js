import { React, useEffect, useState } from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";
import { getCategories } from "../../../services/categoryService.js";
import Category from "./components/Category/index.js";

export default function CategoriesAdmin() {
  const [categories, setCategories] = useState([{}]);
  const { authenticated, getAdminId } = useAuthentication();

  useEffect(() => {
    async function fetchCategories() {
      const categoriesData = await getCategories();
      setCategories(categoriesData);
    }
    fetchCategories();
  }, []);

  return (
    authenticated && (
      <div>
        <h1>Categorias</h1>
        {categories.map((category) => {
          return <Category category={category} key={category.id}/>;
        })}
      </div>
    )
  );
}
