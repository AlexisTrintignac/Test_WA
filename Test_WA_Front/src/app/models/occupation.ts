import { Emploie } from "./emploie";
import { Personne } from "./personne";


export interface Occupation {
    id: number,
    emploiId: number,
    emploi: Emploie,
    personneId: number,
    personne: Personne,
    dateDebut: Date,
    dateFin?: Date
}