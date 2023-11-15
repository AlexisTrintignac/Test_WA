import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreatePersonne } from 'src/app/models/create-personnes';
import { Personne } from 'src/app/models/personne';
import { PersonneDetails } from 'src/app/models/personne-details';
import { PersonneService } from 'src/app/services/personne.service';


@Component({
  selector: 'app-personne',
  templateUrl: './personne.component.html',
  styleUrls: ['./personne.component.scss']
})
export class PersonneComponent {
  
  personneForm: FormGroup;
  personneEntrepriseForm: FormGroup;
  personneWithoutEmploiForm: FormGroup;
  personneWithEmploiForm: FormGroup;
  personnes : PersonneDetails[];
  personnesByEntreprise: PersonneDetails[];
  personnesWithoutEmploie: Personne[] = [];
  personnesWithEmploie: Personne[] = [];

  constructor(private personneService: PersonneService, private fb: FormBuilder) {
    this.personneForm = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      dateNaissance: ['', Validators.required]
    });
    this.personneEntrepriseForm = this.fb.group({
      entreprise: ['', Validators.required],
    });
    this.personneWithoutEmploiForm = this.fb.group({
      dateDebut: ['', Validators.required],
      dateFin: ['', Validators.required],
    });
    this.personneWithEmploiForm = this.fb.group({
      dateDebut1: ['', Validators.required],
      dateFin1: ['', Validators.required],
    });
    this.personnes = []
    this.personnesByEntreprise = [];
  }
  
  ngOnInit() {
    this.personneService.getAllPersonnes().subscribe(data => {
      this.personnes = data;
    });
    
  }
  onSubmit() {
    if (this.personneForm.valid) {
      const personne: CreatePersonne = this.personneForm.value;
      this.personneService.createPersonne(personne).subscribe(
        response => {
          console.log('Personne créée avec succès', response);
        },
        error => {
          console.error('Erreur lors de la création de la personne', error);
        }
      );
    }
  }

  onSubmitEntreprise() {
    const nomEntreprise = this.personneEntrepriseForm.get('entreprise')?.value;
  
    this.personneService.getPersonnesByEntreprise(nomEntreprise).subscribe(
      personnes => {
        this.personnesByEntreprise = personnes;
      },
      error => {
        console.error('Erreur lors de la recherche par entreprise', error);
      }
    );
  }

  onSubmitWithoutEmploi(){
    const datedebut = this.personneWithoutEmploiForm.get('dateDebut')?.value;
    const datefin = this.personneWithoutEmploiForm.get('dateFin')?.value;
  
    this.personneService.getPersonnesWithoutEmploie(datedebut, datefin).subscribe(
      personnes => {
        this.personnesWithoutEmploie = personnes;
      },
      error => {
        console.error('Erreur lors de la recherche', error);
      }
    );
  }

  onSubmitWithEmploi(){
    const datedebut = this.personneWithEmploiForm.get('dateDebut1')?.value;
    const datefin = this.personneWithEmploiForm.get('dateFin1')?.value;
  
    this.personneService.getPersonnesWithEmploie(datedebut, datefin).subscribe(
      personnes => {
        this.personnesWithEmploie = personnes;
      },
      error => {
        console.error('Erreur lors de la recherche', error);
      }
    );
  }
}
