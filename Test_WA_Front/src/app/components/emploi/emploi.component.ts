import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmploiService } from 'src/app/services/emploi.service';
import { Emploie } from "../../models/emploie";
import { CreateEmploie } from "../../models/create-emploie";

@Component({
  selector: 'app-emploi',
  templateUrl: './emploi.component.html',
  styleUrls: ['./emploi.component.scss']
})
export class EmploiComponent {
  emploiForm: FormGroup;
  createEmploiForm: FormGroup;
  emplois: Emploie[] = [];

  constructor(private fb: FormBuilder, private service: EmploiService){
    this.emploiForm = this.fb.group({
      personneId: ['', Validators.required],
      dateDebut: ['', Validators.required],
      dateFin: ['', Validators.required],
    });
    this.createEmploiForm = this.fb.group({
      nomEntreprise: ['', Validators.required],
      nomPoste: ['', Validators.required],
    });
  }

  public onSubmit(){
    const datedebut = this.emploiForm.get('dateDebut')?.value;
    const datefin = this.emploiForm.get('dateFin')?.value;
    const personneId = this.emploiForm.get('personneId')?.value;

    this.service.getEmploieByPersonneAndDate(personneId, datedebut, datefin).subscribe(
      emploiResponse => {
        this.emplois = emploiResponse;
      },
      error => {
        console.error('Erreur lors de la recherche', error);
      }
    );
  }

  public onSubmitCreate(){
    const entreprise = this.createEmploiForm.get('nomEntreprise')?.value;
    const poste = this.createEmploiForm.get('nomPoste')?.value;
    const newEmploie: CreateEmploie = this.createEmploiForm.value;
    console.log(newEmploie);
    this.service.createEmploi(newEmploie).subscribe( response => {
      console.log('Emploi créée avec succès', response);
    },
    error => {
      console.error("Erreur lors de la création de l'emploi", error);
    })
  }
}
