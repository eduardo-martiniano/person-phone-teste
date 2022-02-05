import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-person-phone',
  templateUrl: './create-person-phone.component.html',
  styleUrls: ['./create-person-phone.component.css']
})
export class CreatePersonPhoneComponent implements OnInit {

  form: any;
  updateMode = false;

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.initializeForm();
  }

  create() {
    console.log("create");
    this.initializeCreate();
  }

  update() {
    console.log("update");
    this.initializeCreate();
    this.router.navigate(['']);
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
