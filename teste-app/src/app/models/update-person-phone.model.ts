import { CreatePersonPhoneModel } from "./create-person-phone.model";

export interface UpdatePersonPhoneModel extends CreatePersonPhoneModel {
  businessEntityID: number;
}
