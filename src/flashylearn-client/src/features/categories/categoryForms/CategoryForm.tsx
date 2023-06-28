import { useState } from "react";
import { CategoryDto, CategoryResponseDto, SaveCategoryCommandInput, useCreateCategoryMutation } from "../../../graphql/generated/schema";
import * as yup from 'yup';
import { useNavigate } from "react-router-dom";
import { Alert, Container, Grid, Snackbar } from "@mui/material";
import { Form, Formik } from "formik";
import OmTextField from "../../../components/FormsUI/OmTextField";
import OmSubmitButton from "../../../components/FormsUI/OmSubmitButton";
import OmLoading from "../../../components/elements/OmLoading";

interface CategoryFormProps{
    category: CategoryDto
}

const FORM_VALIDATION = yup.object().shape({
    name: yup.string()
    .required("Name is required")
});

export default function CategoryForm({category}: CategoryFormProps){
    const [open, setOpen] = useState(false);
    const navigate = useNavigate();

    const INITIAL_FORM_STATE = {
        categoryID: category.categoryID,
        name: category.name || '',
        userID: category.userID
    }

    const [createCategory, {loading: createCategoryLoading, error: createCategoryError}] = useCreateCategoryMutation();

    const handleClose = (event: any) => {
        if(event.reason === 'clickaway'){
            return;
        }
        setOpen(false);
    }

    async function createOrUpdateCategoryDetails(values: SaveCategoryCommandInput){
        const response = await (createCategory({variables: {
            category: values
        }}));

        setOpen(true);

        const category = response.data?.saveCategory as CategoryResponseDto;

        if(category.categoryID){
            navigate(`/categories/${category.categoryID}`);
        }

        if(createCategoryLoading){
            return (<OmLoading />)
        }

        if(createCategoryError){
            <Snackbar open={true} autoHideDuration={6000}>
                <Alert security="error">Error Retrieving category data</Alert>
            </Snackbar>
        }
        
    }

    return (<Container>
        <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
            <Alert onClose={handleClose} severity="success" sx={{width : '100%'}}>
                {!category.categoryID ? "Category successfully added!": "Category successfully updated!"}
            </Alert>
        </Snackbar>
        <div>
            <Formik initialValues={INITIAL_FORM_STATE}
            validationSchema={FORM_VALIDATION}
            onSubmit={createOrUpdateCategoryDetails}>
                <Form>
                    <Grid container spacing={2} >
                        <Grid item xs={12}>
                            <OmTextField name="name" otherProps={{label: "Category Name"}} />
                        </Grid>
                        <Grid item xs={12}>
                            <OmSubmitButton otherProps={{}}>{ category.categoryID ? "Update Category" : "Create Category"}</OmSubmitButton>
                        </Grid>
                    </Grid>
                </Form>
            </Formik>
        </div>
    </Container>)
}