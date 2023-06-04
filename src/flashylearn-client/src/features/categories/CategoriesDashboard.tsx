import { useGetCategoriesQuery } from "../../graphql/generated/schema";
export default function CategoriesDashboard(){
    const {data: categoriesData, loading, error } = useGetCategoriesQuery();
    if(loading){
        return <div>Loading</div>
    }

    if(error || !categoriesData){
        return <div>Error...</div>
    }
    
    return <div>
        <h2>Categories</h2>
        <ul>
            {categoriesData.allCategories?.map(category =>(
                <li key={category?.categoryID}>{category.name}</li>
            ))}
        </ul>
    </div>
}