import {Occupation} from './occupation'

export interface Emploie {
    id: number,
    nomEntreprise: string,
    nomPoste: string,
    occupations: Occupation[]
}