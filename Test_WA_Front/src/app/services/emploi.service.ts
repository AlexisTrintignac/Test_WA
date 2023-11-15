import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PersonneDetails } from "../models/personne-details";
import { CreatePersonne } from "../models/create-personnes";
import { Personne } from "../models/personne";
import { Emploie } from "../models/emploie";
import { CreateEmploie } from "../models/create-emploie";

const BASE_API_URL = "https://localhost:7275"

@Injectable({
    providedIn: 'root',
})
export class EmploiService {
    
    constructor(private http: HttpClient) { }

    createEmploi(emploi: CreateEmploie): Observable<any> {
        return this.http.post<any>(`${BASE_API_URL}/Emploi`, emploi, {
            headers: new HttpHeaders({
              'Access-Control-Allow-Origin': '*'
            })
        })
    }

    getEmploieByPersonneAndDate(personneId: number, dateDebut: string, dateFin: string): Observable<Emploie[]> {
        return this.http.get<Emploie[]>(`${BASE_API_URL}/Emploi/${personneId}/${dateDebut}/${dateFin}`);
    }

}
