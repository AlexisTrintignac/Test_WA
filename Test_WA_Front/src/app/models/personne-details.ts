import { Emploie } from "./emploie"

export interface PersonneDetails {
    id: number,
    nom: string,
    prenom: string,
    age: number
    emploies: Emploie[]
}