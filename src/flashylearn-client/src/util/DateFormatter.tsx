import {format } from 'date-fns';
import { DATE_FORMAT, DATE_FORMAT_PICKER } from '../types/Constants';


export function dateFormatter(dateValue: Date){
    if(!dateValue){
        return format(new Date(), DATE_FORMAT);
    }

    return format(new Date(dateValue), DATE_FORMAT);
}

export function dateFormatPicker(dateValue: Date){
    if(!dateValue){
        return format(new Date(), DATE_FORMAT_PICKER);
    }

    return format(new Date(dateValue), DATE_FORMAT_PICKER);

}