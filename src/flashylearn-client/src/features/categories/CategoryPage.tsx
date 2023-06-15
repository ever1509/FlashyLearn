import { useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { CategoryDto, useGetCategoryByIdQuery } from "../../graphql/generated/schema";
import OmLoading from "../../components/elements/OmLoading";
import OmAlert from "../../components/elements/OmAlert";
import { Container, Grid} from "@mui/material";
import CategoryForm from "./categoryForms/CategoryForm";
import OmHeader from "../../components/elements/OmHeader";

export default function CategoryPage(){
    const params = useParams();
    const categoryID = params.categoryID || null;
    const navigate = useNavigate();
    const [open, setOpen] = useState(false);
    const {data: categoryData, loading: categoryLoading, error: categoryError} = useGetCategoryByIdQuery({
        variables: {
            id: categoryID
        }
    });

    if(categoryLoading){
        return <OmLoading />
    }

    if(categoryError || !categoryData || !categoryData.allCategories){
        return <OmAlert message="Error retrieving category data" />
    }

    const category = categoryData.allCategories[0] as CategoryDto;

    return (
        <Container>
            <Grid container spacing={2}>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <OmHeader header={`Category Details ${category.categoryID}`} />
                </Grid>
                <Grid item xs={2}></Grid>
                <Grid item xs={12}>
                    <CategoryForm category={category}/>
                </Grid>
            </Grid>
        </Container>
    )
}