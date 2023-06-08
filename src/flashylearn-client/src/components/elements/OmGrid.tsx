import {AgGridReact} from "ag-grid-react";
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import { useMemo } from "react";

export default function OmGrid({rowData, columnsDefs}: OnGridProps){

    const defaultColDef = useMemo(()=>({
        sortable: true,
        filter: true,
        resizable: true,

    }), []);

    return (<div className="ag-theme-alpine" style={{height: 500, width: '100%',}}>
    <AgGridReact 
        rowData={rowData}
        columnDefs={columnsDefs}
        defaultColDef={defaultColDef}

    />
</div>)
}

interface OnGridProps{
    rowData: any,
    columnsDefs: any
}