import { React, useEffect, useState } from "react";
import useAuthentication from "../../../hooks/useAuthentication";
import { getCategories } from "../../../services/categoryService.js";
import Category from "./components/Category/index.js";
import NewCategoryForm from "./components/NewCategoryForm/index.js";

export default function CategoriesAdmin() {
  const [categories, setCategories] = useState([]);
  const { authenticated } = useAuthentication();

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
        <div>
          <h1>Categorias</h1>
          {categories.length > 0 ? (
            categories.map((category) => {
              return <Category key={category.id} category={category} />;
            })
          ) : (
            <p>Nenhuma categoria cadastrada</p>
          )}
        </div>
        <div>
          <NewCategoryForm />
        </div>
      </div>
    )
  );
}
