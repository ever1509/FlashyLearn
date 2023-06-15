import { Container, Grid } from "@mui/material";
import { CategoryDto } from "../../graphql/generated/schema";
import OmHeader from "../../components/elements/OmHeader";
import CategoryForm from "./categoryForms/CategoryForm";

export default function NewCategoryPage(){
    const category = {} as CategoryDto;
    return(<Container>
        <Grid container spacing={12}>
            <Grid item xs={12}>
                <OmHeader header={"New Category Details"} />
            </Grid>
            <Grid item xs={12}>
                <CategoryForm category={category}/>
            </Grid>
        </Grid>
    </Container>)
}