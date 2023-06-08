import { Alert, Box } from "@mui/material";

interface OmAlertProps{
    message: string
}

export default function OmAlert({message}: OmAlertProps){
    return (<Box sx={{display: 'flex' }}>
    <Alert severity="error">{message}</Alert>
</Box>)
}