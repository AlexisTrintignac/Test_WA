import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { PersonneComponent } from './components/personne/personne.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EmploiComponent } from './components/emploi/emploi.component';


@NgModule({
  declarations: [
    AppComponent,
    PersonneComponent,
    EmploiComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
