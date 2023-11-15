import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PersonneDetails } from "../models/personne-details";
import { CreatePersonne } from "../models/create-personnes";
import { Personne } from "../models/personne";

const BASE_API_URL = "https://localhost:7275"

@Injectable({
    providedIn: 'root',
})
export class PersonneService {
    
    constructor(private http: HttpClient) { }

    getAllPersonnes(): Observable<PersonneDetails[]> {
        return this.http.get<any>(`${BASE_API_URL}/Personne/GetAllPersonnes`);
    }

    createPersonne(personne: CreatePersonne): Observable<any> {
        return this.http.post<any>(`${BASE_API_URL}/Personne/CreatePersonne`, personne, {
            headers: new HttpHeaders({
              'Access-Control-Allow-Origin': '*'
            })
        })
    }

    getPersonnesByEntreprise(entreprise: string): Observable<PersonneDetails[]> {
        return this.http.get<any>(`${BASE_API_URL}/Personne/${entreprise}`);
    }

    getPersonnesWithoutEmploie(dateDebut: string, dateFin: string): Observable<Personne[]> {
        return this.http.get<Personne[]>(`${BASE_API_URL}/Personne/WithoutEmploi/${dateDebut}/${dateFin}`);
    }

    getPersonnesWithEmploie(dateDebut: string, dateFin: string): Observable<Personne[]> {
        return this.http.get<Personne[]>(`${BASE_API_URL}/Personne/WithEmploi/${dateDebut}/${dateFin}`);
    }
}
