import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreatePersonPhoneModel } from '../models/create-person-phone.model';
import { PersonPhoneModel } from '../models/person-phone.model';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {

  api_url = `${environment.API_URL}/person-phones`;
  constructor(private http: HttpClient) { }

  getPersonPhones(): Promise<PersonPhoneModel[]> {
    return new Promise((resolve, reject) => {
      this.http.get<PersonPhoneModel[]>(this.api_url).subscribe(
        result => {
          resolve(result);
        },
        error => reject(error))
    });
  }

  delete(businessEntityID: number): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(`${this.api_url}/${businessEntityID}`).subscribe(
        result => {
          resolve(result);
        },
        error => reject(error))
    });
  }

  create(personPhone: CreatePersonPhoneModel): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(`${this.api_url}`, personPhone).subscribe(
        result => {
          resolve(result);
        },
        error => reject(error))
    });
  }
}
