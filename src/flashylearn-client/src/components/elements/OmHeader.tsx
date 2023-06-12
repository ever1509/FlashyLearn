import { Typography } from "@mui/material"

interface OmHeaderProps{
    header:string
}

export default function OmHeader({header}: OmHeaderProps){
    return(<Typography component="div" variant="h5" display="block" gutterBottom align="center">
    {header}
</Typography>)
}