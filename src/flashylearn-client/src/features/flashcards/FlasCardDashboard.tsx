import { Grid, Typography } from "@mui/material";
import { FlashCardDto, useRunFlashardsQuery } from "../../graphql/generated/schema";
import FlashCardList from "./FlashCardList";

export default function FlashCardDashboard(){
    const {data: flashCardsData, loading, error } = useRunFlashardsQuery();
    if(loading){
        return <div>Loading</div>
    }

    if(error || !flashCardsData){
        return <div>Error...</div>
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