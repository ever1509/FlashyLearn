import { useState } from "react";
import { TagDto } from "../../graphql/generated/schema";
import { Button, Container, Grid } from "@mui/material";
import { More } from "@mui/icons-material";
import OmGrid from "../../components/elements/OmGrid";

interface TagListProps{
    tags: TagDto[]
}

export default function TagList({tags}: TagListProps){
    const [columnsDefs] = useState([
        {
            field: 'flashCardID',
            width: 400,
            supressSizeToFit:true,
            title:'FlashCard ID',
            cellRenderer: function(params: any){
                return (<Button variant="outlined" color="primary" startIcon={<More />} 
                onClick={()=> window.open(`/flashcards/${params.value}`)}></Button>)
            }
        },
        {
            field: 'tagID',
            width: 400,
            supressSizeToFit:true,
            title:'Tag ID'
        }
    ]);

    return ( 
        <Container>
            <Grid container spacing={2}>
            <Grid item xs={12}>
            <Button variant='contained' fullWidth={true} href={"/tags/new"}>Add New Tag</Button>
            </Grid>
            <Grid item xs={12}>
            <OmGrid 
        rowData={tags}
        columnsDefs={columnsDefs}/>
            </Grid>
            </Grid>
        </Container>
        )

}