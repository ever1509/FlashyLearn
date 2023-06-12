import { useState } from "react"
import { CategoryDto } from "../../graphql/generated/schema";
import OmGrid from "../../components/elements/OmGrid";
import { IconButton } from "@mui/material";

export default function CategoriesList({categories}: CategoryListProps){
    const [columnsDefs] = useState([
        {
            field: 'categoryID',
            width: 400,
            supressSizeToFit:true,
            title:'Category ID',
            cellRenderer: function(params: any){
                return (<IconButton onClick={()=> window.open(`/categories/${params.value}`)} />)
            }
        },
        {
            field: 'name',
            title: 'Category Name'
        }
    ]);

    return (
        <OmGrid 
            rowData={categories}
            columnsDefs={columnsDefs}
        />)
}

interface CategoryListProps {
    categories: CategoryDto []
}