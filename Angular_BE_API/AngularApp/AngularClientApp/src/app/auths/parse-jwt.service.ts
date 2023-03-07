import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenDataModel } from './viewModels';

import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class ParseJWTService {

  constructor() { }

  GetUserData(): Observable<TokenDataModel>{
    var token = localStorage.getItem("token");
    if(token == null || token == undefined || token === ""){
      return new Observable<TokenDataModel>(subscriber => {
        subscriber.next(undefined);
        subscriber.complete();
      });
    }

    var user = new TokenDataModel();

    var data = jwt_decode(token) as any;

    var date = data.exp * 1000;

    if(new Date() > new Date(date)){
      return new Observable<TokenDataModel>(subscriber => {
        subscriber.next(undefined);
        subscriber.complete();
      });
    }

    user.token = token;
    user.name = data.unique_name;
    user.surname = data.family_name;
    user.email = data.email;
    user.phone = data.phone;
    user.expired = new Date(date);

    return new Observable<TokenDataModel>(subscriber => {
      subscriber.next(user);
      subscriber.complete();
    })
  }
}

