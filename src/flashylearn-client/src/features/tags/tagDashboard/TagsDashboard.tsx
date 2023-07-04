import { useParams } from "react-router-dom";
import OmAlert from "../../../components/elements/OmAlert";
import OmLoading from "../../../components/elements/OmLoading";
import { TagDto, useAllTagsQuery } from "../../../graphql/generated/schema";
import { Grid, Typography } from "@mui/material";
import TagList from "../TagList";

export default function TagsDashboard(){
    const params = useParams();
    let flashCardID = params.flashCardID || "";
    const {data: tagsData, loading, error } = useAllTagsQuery({
        variables:{
            flashCardID : flashCardID
        }
    });
    if(loading){
        return <OmLoading />
    }

    if(error || !tagsData){
        return <OmAlert message="Could not load tags data" />
    }

    const tags = tagsData.allTags as TagDto[];
    return <div>
    <Grid container spacing={2}>
        <Grid item xs={12} >
            <Typography component="div" variant="h5" display="block" gutterBottom align="center">
                Tag List
            </Typography>
        </Grid>
        <Grid item xs={12} >
            <TagList tags={tags} />
        </Grid>
    </Grid>
</div>
}