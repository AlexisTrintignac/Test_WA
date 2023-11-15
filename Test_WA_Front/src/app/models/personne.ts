import { Occupation } from "./occupation"

export interface Personne {
    id: number,
    nom: string,
    prenom: string,
    dateNaissance: Date
    occupations: Occupation[]
}