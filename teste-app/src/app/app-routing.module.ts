import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CreatePersonPhoneComponent } from "./components/create-person-phone/create-person-phone.component";
import { PersonPhonesComponent } from "./components/person-phones/person-phones.component";

const routes: Routes = [
  {
    path: '',
    component: PersonPhonesComponent
  },
  {
    path: 'create',
    component: CreatePersonPhoneComponent
  },
  {
    path: 'update',
    component: CreatePersonPhoneComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
