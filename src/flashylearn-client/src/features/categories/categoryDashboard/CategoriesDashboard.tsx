import { Grid, Typography } from "@mui/material";
import { CategoryDto, useGetCategoriesQuery } from "../../../graphql/generated/schema";
import CategoriesList from "./CategoriesList";
import OmLoading from "../../../components/elements/OmLoading";
import OmAlert from "../../../components/elements/OmAlert";
export default function CategoriesDashboard(){
    const {data: categoriesData, loading, error } = useGetCategoriesQuery();
    if(loading){
        return <OmLoading />
    }

    if(error || !categoriesData){
        return <OmAlert message="Could not load categories data" />
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