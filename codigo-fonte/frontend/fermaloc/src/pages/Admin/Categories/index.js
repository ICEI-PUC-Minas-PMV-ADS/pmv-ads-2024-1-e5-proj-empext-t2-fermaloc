import { React, useEffect, useState } from "react";
import useAuthentication from "../../../hooks/useAuthentication";
import { getCategoriesByStatus } from "../../../services/categoryService.js";
import Category from "./components/Category/index.js";
import NewCategoryForm from "./components/NewCategoryForm/index.js";
import FilterStatus from "../../../components/FilterStatus/index.js";

export default function CategoriesAdmin() {
  const [categories, setCategories] = useState([]);
  const { authenticated } = useAuthentication();

  useEffect(() => {
    async function fetchCategories() {
      const categoriesData = await getCategoriesByStatus();
      setCategories(categoriesData);
    }
    fetchCategories();
  }, []);


  async function handleFilter(status){
    const productsData = await getCategoriesByStatus(status);
    setCategories(productsData);
  }

  return (
    authenticated && (
      <div>
        <div>
          <h1>Categorias</h1>
          <FilterStatus handleFilter={handleFilter}/>
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
