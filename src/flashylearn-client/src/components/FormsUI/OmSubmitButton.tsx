import { Button } from "@mui/material";
import { useFormikContext } from "formik"

interface OnSubmitButtonProps{
    children: any,
    otherProps: any   
}

export default function OmSubmitButton({children, otherProps}: OnSubmitButtonProps){
    const {submitForm} = useFormikContext();

    function handleSubmit(){
        submitForm();
    }

    const configButton = {
        ...otherProps,
        color: 'primary',
        variant: 'contained',
        fullWidth: true,
        onclick: handleSubmit
    };

    return (<Button {...configButton}  >{children}</Button>)
}