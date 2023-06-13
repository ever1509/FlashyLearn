import { useState } from "react";
import { CategoryDto, FlashCardDto, Frequency, useGetCategoriesQuery } from "../../../graphql/generated/schema";
import * as yup from 'yup';
import { useNavigate } from "react-router-dom";
import { Container, Grid } from "@mui/material";
import { Form, Formik } from "formik";
import OmTextField from "../../../components/FormsUI/OmTextField";
import OmSubmitButton from "../../../components/FormsUI/OmSubmitButton";
import OmSelect from "../../../components/FormsUI/OmSelect";
import OmLoading from "../../../components/elements/OmLoading";
import OmAlert from "../../../components/elements/OmAlert";

interface FlashCardFormProps{
    flashCard: FlashCardDto
}

const FORM_VALIDATION = yup.object().shape({
    backText: yup.string().required("Back Text is required"),
    categoryID: yup.string().required("Category Id is required"),
    frontText: yup.string().required("Front Text is required")
});

export default function FlashCardForm({flashCard}: FlashCardFormProps){
    function createFlashCard(values: any){
        console.log(values);
    }

    const [open, setOpen] = useState(false);
    const navigate = useNavigate();


    const {data: categoriesData, loading, error } = useGetCategoriesQuery();
    if(loading){
        return <OmLoading />
    }

    if(error || !categoriesData){
        return <OmAlert message="Could not load categories data" />
    }

    const INITIAL_FORM_STATE = {
        flashcarID: flashCard.flashCardID,
        categoryID: flashCard.categoryID,
        backText: flashCard.backText || '',
        frontText: flashCard.frontText || '',
        frequency: flashCard.frequency || Frequency.Daily,
    }

    return (<Container>
        <div>
            <Formik
            initialValues={INITIAL_FORM_STATE}
            validationSchema={FORM_VALIDATION}
            onSubmit={createFlashCard}>
                <Form>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <OmTextField name="backText" otherProps={{label: "Back Text"}} />
                        </Grid>
                        <Grid item xs={12}>
                            <OmTextField name="frontText" otherProps={{label: "Front Text"}} />
                        </Grid>
                        <Grid item xs={8}>
                            <OmSelect 
                                name="frequency"
                                otherProps={{label: "Frequency"}}
                                options={Frequency}
                            />
                        </Grid>
                        <Grid item xs={12}>
                        <OmSelect 
                                name="categoryID"
                                otherProps={{label: "Category"}}
                                options={categoriesData.allCategories.map(category => (category.name))}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <OmSubmitButton otherProps={{}}>{ flashCard.flashCardID ? "Update FlasCard" : "Create FlashCard"}</OmSubmitButton>
                        </Grid>

                    </Grid>
                </Form>

            </Formik>
        </div>
    </Container>)
}