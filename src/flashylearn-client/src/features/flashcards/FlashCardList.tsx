import { useState } from "react";
import { FlashCardDto } from "../../graphql/generated/schema"
import OmGrid from "../../components/elements/OmGrid";

interface FlashCardProps{
    flashCards: FlashCardDto[]
}

export default function FlashCardList({flashCards}: FlashCardProps){
    const [columnsDefs] = useState([
        {
            field: 'flashCardID',
            width: 400,
            supressSizeToFit:true,
            title:'FlashCard ID'
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

    return ( <OmGrid 
        rowData={flashCards}
        columnsDefs={columnsDefs}
    />)
}