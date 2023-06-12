import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { FlashCardDto, useRunFlashardByIdQuery } from "../../graphql/generated/schema";
import OmLoading from "../../components/elements/OmLoading";
import OmAlert from "../../components/elements/OmAlert";
import { Container, Grid } from "@mui/material";
import FlashCardForm from "./flashcardforms/FlashCardForm";
import OmHeader from "../../components/elements/OmHeader";

export default function FlashCardPage(){
    const params = useParams();
    const flashCardID = params.flashCardID || null;
    const navigate = useNavigate();
    const [open, setOpen] = useState(false);

    const {data: flashCardData, loading: flashCardLoading, error: flashCardError} = useRunFlashardByIdQuery({
        variables:{
            id: flashCardID
        }
    })

    if(flashCardLoading){
        return <OmLoading />
    }

    if(flashCardError || !flashCardData || !flashCardData.runFlashCards){
        return <OmAlert message="Error retrieving flashcard data" />
    }

    const flashCard = flashCardData.runFlashCards[0] as FlashCardDto;

    return (
        <Container>
            <Grid container spacing={2}>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <OmHeader header={`FlashCard Details ${flashCard.flashCardID}`} />
                </Grid>
                <Grid item xs={2}></Grid>
                <Grid item xs={12}>
                    <FlashCardForm flashCard={flashCard}/>
                </Grid>
            </Grid>
        </Container>
    )

}