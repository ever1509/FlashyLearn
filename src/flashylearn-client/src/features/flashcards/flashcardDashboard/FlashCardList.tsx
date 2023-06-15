import { useState } from "react";
import { FlashCardDto } from "../../../graphql/generated/schema"
import OmGrid from "../../../components/elements/OmGrid";
import { Button, Container, Grid, Link } from "@mui/material";
import { useNavigate } from "react-router-dom";

interface FlashCardProps{
    flashCards: FlashCardDto[]
}

export default function FlashCardList({flashCards}: FlashCardProps){
    const [columnsDefs] = useState([
        {
            field: 'flashCardID',
            width: 400,
            supressSizeToFit:true,
            title:'FlashCard ID',
            cellRenderer: function(params: any){
                return (<Link onClick={()=> window.open(`/flashcards/${params.value}`)}>{params.value}
                </Link>)
            }
        },
        {
            field: 'categoryID',
            width: 400,
            supressSizeToFit:true,
            title:'Category ID'
        },
        {
            field: 'backText',
            width: 400,
            supressSizeToFit:true,
            title:'Back text'
        },
        {
            field: 'frontText',
            width: 400,
            supressSizeToFit:true,
            title:'Front text'
        },
        {
            field: 'frequency',
            width: 400,
            supressSizeToFit:true,
            title:'Frequency'
        }
    ]);

    return ( 
        <Container>
            <Grid container spacing={2}>
            <Grid item xs={12}>
            <Button variant='contained' fullWidth={true} href={"/flashcards/new"}>Add New FlashCard</Button>
            </Grid>
            <Grid item xs={12}>
            <OmGrid 
        rowData={flashCards}
        columnsDefs={columnsDefs}/>
            </Grid>
            </Grid>
        </Container>
        )
}