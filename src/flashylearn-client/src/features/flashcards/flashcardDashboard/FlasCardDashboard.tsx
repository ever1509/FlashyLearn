import { Grid, Typography } from "@mui/material";
import { FlashCardDto, useRunFlashardsQuery } from "../../../graphql/generated/schema";
import FlashCardList from "./FlashCardList";
import OmAlert from "../../../components/elements/OmAlert";
import OmLoading from "../../../components/elements/OmLoading";

export default function FlashCardDashboard(){
    const {data: flashCardsData, loading, error } = useRunFlashardsQuery();
    if(loading){
        return <OmLoading />
    }

    if(error || !flashCardsData){
        return <OmAlert message="Could not load flashcards data" />
    }

    const flashCards = flashCardsData.runFlashCards as FlashCardDto[];
    
    return <div>
        <Grid container spacing={2}>
            <Grid item xs={12} >
                <Typography component="div" variant="h5" display="block" gutterBottom align="center">
                    Order List
                </Typography>
            </Grid>
            <Grid item xs={12} >
                <FlashCardList flashCards={flashCards} />
            </Grid>
        </Grid>
    </div>
}