import { useMemo, useState } from "react"
import { CategoryDto } from "../../graphql/generated/schema";
import {AgGridReact} from "ag-grid-react";
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';


export default function CategoriesList({categories}: CategoryListProps){
    const [columnsDefs] = useState([
        {
            field: 'categoryID',
            width: 400,
            supressSizeToFit:true,
            title:'Category ID'
        },
        {
            field: 'name',
            title: 'Category Name'
        }
    ]);

    const defaultColDef = useMemo(()=>({
        sortable: true,
        filter: true,
        resizable: true,

    }), []);

    return (<div className="ag-theme-alpine" style={{height: 500, width: '100%',}}>
        <AgGridReact 
            rowData={categories}
            columnDefs={columnsDefs}
            defaultColDef={defaultColDef}

        />
    </div>)
}

interface CategoryListProps {
    categories: CategoryDto []
}