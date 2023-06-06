import { useMemo, useState } from "react";
import { FlashCardDto } from "../../graphql/generated/schema"
import { AgGridReact } from "ag-grid-react";

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

    const defaultColDef = useMemo(()=>({
        sortable: true,
        filter: true,
        resizable: true,
    }), []);

    return (<div className="ag-theme-alpine" style={{height: 500, width: '100%',}}>
    <AgGridReact 
        rowData={flashCards}
        columnDefs={columnsDefs}
        defaultColDef={defaultColDef}

    />
</div>)
}