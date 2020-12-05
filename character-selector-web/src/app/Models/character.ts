import {Option} from './option';

export interface Character{
    id: string;
    type: string;
    name: string;
    description: string;
    imgUrl: string;
    options: Option[];
    selectedOptions: string[];
    userId: string;
}
