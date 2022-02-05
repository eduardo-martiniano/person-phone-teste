import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-phones',
  templateUrl: './person-phones.component.html',
  styleUrls: ['./person-phones.component.css']
})
export class PersonPhonesComponent implements OnInit {

  personPhones: any = [
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
    {businessEntityID: 1, phoneNumber: "(99) 9 9999-9999", phoneNumberType: "Pessoal", phoneNumberTypeID: 1, name: "Eduardo"},
  ]
  constructor(private router: Router) { }

  ngOnInit() {
  }

  delete(id: number){
    console.log("Delete");
  }

  update(personPhone: any){
    this.router.navigate(['update', {personPhone: JSON.stringify(personPhone)}]);
  }

}
