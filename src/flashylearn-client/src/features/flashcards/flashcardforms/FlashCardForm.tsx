import { useState } from "react";
import { SaveFlashCardCommandInput, FlashCardDto, FlashCardResponseDto, Frequency, useSaveFlashCardMutation, useGetCategoriesQuery } from "../../../graphql/generated/schema";
import * as yup from 'yup';
import { useNavigate } from "react-router-dom";
import { Alert, Container, Grid, Snackbar } from "@mui/material";
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

    const [createOrUpdateFlashCard, {loading: createOrUpdateFlashCardLoading, error: createOrUpdateFlashCardError}] = useSaveFlashCardMutation();

    const handleClose = (event: any) => {
        if(event.reason === 'clickaway'){
            return;
        }
        setOpen(false);
    }
    
    async function createOrUpdateFlashCardDetails(values: SaveFlashCardCommandInput){
        const response = await createOrUpdateFlashCard({variables:{
            flashCard: values
        }});

        setOpen(true);

        const flashCard = response.data?.saveFlashCard as FlashCardResponseDto;

        if(flashCard.flashCardID){
            navigate(`/flashcards/${flashCard.flashCardID}`);
        }

        if(createOrUpdateFlashCardLoading){
            return (<OmLoading />)
        }

        if(createOrUpdateFlashCardError){
            <Snackbar open={true} autoHideDuration={6000}>
                <Alert security="error">Error Retrieving flashcard data</Alert>
            </Snackbar>
        }
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
                <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
            <Alert onClose={handleClose} severity="success" sx={{width : '100%'}}>
                {!flashCard.flashCardID ? "FlashCard successfully added!": "FlashCard successfully updated!"}
            </Alert>
        </Snackbar>
        <div>
            <Formik
            initialValues={INITIAL_FORM_STATE}
            validationSchema={FORM_VALIDATION}
            onSubmit={createOrUpdateFlashCardDetails}>
                <Form>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <OmTextField name="backText" otherProps={{label: "Back Text"}} />
                        </Grid>
                        <Grid item xs={12}>
                            <OmTextField name="frontText" otherProps={{label: "Front Text"}} />
                        </Grid>
                        <Grid item xs={12}>
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