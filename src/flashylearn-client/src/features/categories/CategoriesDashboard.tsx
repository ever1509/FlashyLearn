import { Grid, Typography } from "@mui/material";
import { CategoryDto, useGetCategoriesQuery } from "../../graphql/generated/schema";
import CategoriesList from "./CategoriesList";
export default function CategoriesDashboard(){
    const {data: categoriesData, loading, error } = useGetCategoriesQuery();
    if(loading){
        return <div>Loading</div>
    }

    if(error || !categoriesData){
        return <div>Error...</div>
    }

    const categories = categoriesData.allCategories as CategoryDto[];
    
    return <div>
        <Grid container spacing={2}>
            <Grid item xs={12} >
                <Typography component="div" variant="h5" display="block" gutterBottom align="center">
                    Categories List
                </Typography>
            </Grid>
            <Grid item xs={12} >
                <CategoriesList categories={categories} />
            </Grid>
        </Grid>
    </div>
}