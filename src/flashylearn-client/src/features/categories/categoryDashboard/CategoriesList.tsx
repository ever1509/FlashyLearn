import { useState } from "react"
import { CategoryDto } from "../../../graphql/generated/schema";
import OmGrid from "../../../components/elements/OmGrid";
import {Button, Container, Grid} from "@mui/material";
import { More } from "@mui/icons-material";

export default function CategoriesList({categories}: CategoryListProps){
    const [columnsDefs] = useState([
        {
            field: 'categoryID',
            width: 400,
            supressSizeToFit:true,
            title:'Category ID',
            cellRenderer: function(params: any){
                return (<Button variant="outlined" color="primary" startIcon={<More />} 
                onClick={()=> window.open(`/categories/${params.value}`)}></Button>)
            }
        },
        {
            field: 'name',
            title: 'Category Name'
        }
    ]);

    return (
        <Container>
            <Grid container spacing={2}>
            <Grid item xs={12}>
            <Button variant='contained' fullWidth={true} href={"/categories/new"}>Add New Category</Button>
            </Grid>
            <Grid item xs={12}>
            <OmGrid 
            rowData={categories}
            columnsDefs={columnsDefs}
        />      
            </Grid>     
        </Grid>
        </Container>
        )
}

interface CategoryListProps {
    categories: CategoryDto []
}