import { Container, Grid } from "@mui/material";
import { FlashCardDto } from "../../graphql/generated/schema";
import OmHeader from "../../components/elements/OmHeader";
import FlashCardForm from "./flashcardforms/FlashCardForm";

export default function NewFlashCardPage(){
    const flashcard = {} as FlashCardDto;
    return(<Container>
        <Grid container spacing={12}>
            <Grid item xs={12}>
                <OmHeader header={"New FlashCard Details"} />
            </Grid>
            <Grid item xs={12}>
                <FlashCardForm flashCard={flashcard}/>
            </Grid>
        </Grid>
    </Container>)
}