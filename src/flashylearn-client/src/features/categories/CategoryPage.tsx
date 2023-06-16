import { useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { CategoryDto, useDeleteCategoryMutation, useGetCategoryByIdQuery } from "../../graphql/generated/schema";
import OmLoading from "../../components/elements/OmLoading";
import OmAlert from "../../components/elements/OmAlert";
import { Button, Container, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid} from "@mui/material";
import CategoryForm from "./categoryForms/CategoryForm";
import OmHeader from "../../components/elements/OmHeader";
import { Delete } from "@mui/icons-material";

export default function CategoryPage(){
    const params = useParams();
    const categoryID = params.categoryID || "";
    const navigate = useNavigate();
    const [open, setOpen] = useState(false);
    const {data: categoryData, loading: categoryLoading, error: categoryError} = useGetCategoryByIdQuery({
        variables: {
            id: categoryID
        }
    });

    const [deleteCategory,{loading: deleteCategoryLoading, error: deleteCategoryError}] = useDeleteCategoryMutation();

    async function DeleteCategoryDetails(){
        const response = await deleteCategory({variables:{
            id: categoryID
        }})

        if(!response.errors){
            navigate(`/categories`);
        }
    }

    function handleClickOpen(){
        setOpen(true);
    }

    function handleClose(){
        setOpen(false);
    }



    if(categoryLoading || deleteCategoryLoading){
        return <OmLoading />
    }

    if(categoryError || !categoryData || !categoryData.allCategories){
        return <OmAlert message="Error retrieving category data" />
    }

    if(deleteCategoryError){
        return <OmAlert message="Error deleting category data" />
    }

    const category = categoryData.allCategories[0] as CategoryDto;

    return (
        <Container>
            <Dialog 
                open={open}
                onClose={handleClose}
                aria-labelledby='alert-dialog-title'
                aria-describedby='alert-dialog-description'
            >
                <DialogTitle id='alert-dialog-title'>{"Delete Category Details?"}</DialogTitle>
                <DialogContent>
                    <DialogContentText id='alert-dialog-description'>
                        You are about to remove this category. Confirm to continue or cancel
                    </DialogContentText>
                    <DialogActions>
                        <Button onClick={handleClose}>Cancel</Button>
                        <Button onClick={DeleteCategoryDetails} color="error" autoFocus>Delete</Button>

                    </DialogActions>
                </DialogContent>

            </Dialog>
            <Grid container spacing={2}>
                <Grid item xs={2}>
                </Grid>
                <Grid item xs={8}>
                    <OmHeader header={`Category Details ${category.categoryID}`} />
                </Grid>
                <Grid item xs={2}>
                <Button variant="outlined" color="error" startIcon={<Delete />} onClick={handleClickOpen}>
                        Delete
                    </Button>
                </Grid>
                <Grid item xs={12}>
                    <CategoryForm category={category}/>
                </Grid>
            </Grid>
        </Container>
    )
}