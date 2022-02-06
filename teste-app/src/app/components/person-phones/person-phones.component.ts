import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PersonPhoneModel } from 'src/app/models/person-phone.model';
import { PersonPhoneService } from 'src/app/services/person-phone.service';

@Component({
  selector: 'app-person-phones',
  templateUrl: './person-phones.component.html',
  styleUrls: ['./person-phones.component.css']
})
export class PersonPhonesComponent implements OnInit {

  personPhones: PersonPhoneModel[];
  constructor(private router: Router, private personPhoneService: PersonPhoneService) { }

  ngOnInit() {
    this.personPhoneService.getPersonPhones().then(response => this.personPhones = response);
  }

  delete(id: number){
    this.personPhoneService.delete(id).then(
      () => this.personPhoneService.getPersonPhones()
      .then(response => this.personPhones = response));
  }

  update(personPhone: any){
    this.router.navigate(['update', {personPhone: JSON.stringify(personPhone)}]);
  }

}
