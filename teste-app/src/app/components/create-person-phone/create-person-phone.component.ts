import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreatePersonPhoneModel } from 'src/app/models/create-person-phone.model';
import { PhoneNumberTypeModel } from 'src/app/models/phone-number-type.model';
import { UpdatePersonPhoneModel } from 'src/app/models/update-person-phone.model';
import { PersonPhoneService } from 'src/app/services/person-phone.service';

@Component({
  selector: 'app-create-person-phone',
  templateUrl: './create-person-phone.component.html',
  styleUrls: ['./create-person-phone.component.css']
})
export class CreatePersonPhoneComponent implements OnInit {

  form: any;
  types: PhoneNumberTypeModel[];
  updateMode = false;

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private personPhoneService: PersonPhoneService,
              private router: Router) { }

  ngOnInit() {
    this.initializeForm();
    this.personPhoneService.getPhoneNumberTypes()
    .then(response => this.types = response);
  }

  create() {
    this.personPhoneService.create(this.form.value as CreatePersonPhoneModel)
      .then(() => this.initializeCreate());
  }

  update() {
    this.personPhoneService.update(this.form.value as UpdatePersonPhoneModel).then(() =>
    {
      this.initializeCreate();
      this.router.navigate(['']);
    });
  }

  initializeForm(){
    let updatePersonPhone = JSON.parse(this.route.snapshot.paramMap.get('personPhone'));
    if (updatePersonPhone != null) {
      this.initializeUpdate(updatePersonPhone);
      this.updateMode = true;
    }
    else {
      this.initializeCreate();
    }
  }

  initializeUpdate(personPhone: any){
    this.form = this.fb.group({
      businessEntityID: [personPhone.businessEntityID, [Validators.required]],
      phoneNumber: [personPhone.phoneNumber, [Validators.required]],
      phoneNumberTypeID: [personPhone.phoneNumberTypeID, [Validators.required]],
    });
  }

  initializeCreate(){
    this.form = this.fb.group({
      phoneNumber: ['', [Validators.required, Validators.maxLength(20)]],
      phoneNumberTypeID: ['', [Validators.required, Validators.maxLength(20)]],
    });
  }

  get formInvalid(): boolean {
    return !this.form.valid;
  }

}
