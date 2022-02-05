import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PersonPhonesComponent } from './components/person-phones/person-phones.component';
import { CreatePersonPhoneComponent } from './components/create-person-phone/create-person-phone.component';

@NgModule({
  declarations: [
    AppComponent,
    SidenavComponent,
    PersonPhonesComponent,
    CreatePersonPhoneComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
