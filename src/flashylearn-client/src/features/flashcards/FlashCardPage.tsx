import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { FlashCardDto, useDeleteFlashCardMutation, useRunFlashardByIdQuery } from "../../graphql/generated/schema";
import OmLoading from "../../components/elements/OmLoading";
import OmAlert from "../../components/elements/OmAlert";
import { Button, Container, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid } from "@mui/material";
import FlashCardForm from "./flashcardforms/FlashCardForm";
import OmHeader from "../../components/elements/OmHeader";
import { Delete } from "@mui/icons-material";

export default function FlashCardPage(){
    const params = useParams();
    const flashCardID = params.flashCardID || '';
    const navigate = useNavigate();
    const [open, setOpen] = useState(false);

    const {data: flashCardData, loading: flashCardLoading, error: flashCardError} = useRunFlashardByIdQuery({
        variables:{
            id: flashCardID
        }
    })

    const [deleteFlashCard, {loading: deleteFlashCardLoading, error: deleteFlashCardError}] = useDeleteFlashCardMutation();

    async function DeleteFlashCardDetails(){
        const response = await deleteFlashCard({
            variables:{
                id: flashCardID
            }
        })

        if(!response.errors){
                navigate(`/flashcards`);
        }
    }

    function handleClickOpen(){
        setOpen(true);
    }

    function handleClose(){
        setOpen(false);
    }

    if(flashCardLoading || deleteFlashCardLoading){
        return <OmLoading />
    }

    if(flashCardError || !flashCardData || !flashCardData.runFlashCards){
        return <OmAlert message="Error retrieving flashcard data" />
    }

    if(deleteFlashCardError){
        return <OmAlert message="Error deleting FlashCard Data" />
    }

    const flashCard = flashCardData.runFlashCards[0] as FlashCardDto;

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
                        You are about to remove this flashCard. Confirm to continue or cancel
                    </DialogContentText>
                    <DialogActions>
                        <Button onClick={handleClose}>Cancel</Button>
                        <Button onClick={DeleteFlashCardDetails} color="error" autoFocus>Delete</Button>

                    </DialogActions>
                </DialogContent>

            </Dialog>
            <Grid container spacing={2}>
                <Grid item xs={2}></Grid>
                <Grid item xs={8}>
                    <OmHeader header={`FlashCard Details ${flashCard.flashCardID}`} />
                </Grid>
                <Grid item xs={2}>
                    <Button variant="outlined" color="error" startIcon={<Delete />} onClick={handleClickOpen}>
                        Delete
                    </Button>
                </Grid>
                <Grid item xs={12}>
                    <FlashCardForm flashCard={flashCard}/>
                </Grid>
            </Grid>
        </Container>
    )

}