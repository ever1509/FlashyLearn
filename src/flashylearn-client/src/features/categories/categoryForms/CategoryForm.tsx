import { useState } from "react";
import { CategoryDto } from "../../../graphql/generated/schema";
import * as yup from 'yup';
import { useNavigate } from "react-router-dom";
import { Container, Grid } from "@mui/material";
import { Form, Formik } from "formik";
import OmTextField from "../../../components/FormsUI/OmTextField";
import OmSubmitButton from "../../../components/FormsUI/OmSubmitButton";

interface CategoryFormProps{
    category: CategoryDto
}

const FORM_VALIDATION = yup.object().shape({
    name: yup.string()
    .required("Name is required")
});

export default function CategoryForm({category}: CategoryFormProps){
    function createCategory(values: any){
        console.log(values);
    }


    const [open, setOpen] = useState(false);
    const navigate = useNavigate();

    const INITIAL_FORM_STATE = {
        categoryID: category.categoryID,
        name: category.name || ''
    }

    return (<Container>
        <div>
            <Formik initialValues={INITIAL_FORM_STATE}
            validationSchema={FORM_VALIDATION}
            onSubmit={createCategory}>
                <Form>
                    <Grid container spacing={2} >
                        <Grid item xs={6}>
                            <OmTextField name="name" otherProps={{label: "Category Name"}} />
                        </Grid>
                        <Grid item xs={6}>
                            <OmSubmitButton otherProps={{}}>{ category.categoryID ? "Update Category" : "Create Category"}</OmSubmitButton>
                        </Grid>
                    </Grid>
                </Form>
            </Formik>
        </div>
    </Container>)
}