import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Test_WA_Front';
  constructor(private router: Router) { }

  public goPersonnePage(){
    this.router.navigate(['/personne']);
  }
}
