import { useState } from "react"
import { CategoryDto } from "../../../graphql/generated/schema";
import OmGrid from "../../../components/elements/OmGrid";
import {Button, Container, Grid, Link } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function CategoriesList({categories}: CategoryListProps){
    const [columnsDefs] = useState([
        {
            field: 'categoryID',
            width: 400,
            supressSizeToFit:true,
            title:'Category ID',
            cellRenderer: function(params: any){
                return (<Link onClick={()=> window.open(`/categories/${params.value}`)}>{params.value}
                </Link>)
            }
        },
        {
            field: 'name',
            title: 'Category Name'
        }
    ]);

    return (
        <Container>
            <Grid item spacing={12}>
            <Button variant='contained' fullWidth={true} href={"/categories/new"}>Add New Category</Button>
            </Grid>
            <OmGrid 
            rowData={categories}
            columnsDefs={columnsDefs}
        />           
        </Container>
        )
}

interface CategoryListProps {
    categories: CategoryDto []
}