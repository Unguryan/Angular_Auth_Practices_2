import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenDataModel } from './viewModels';

@Injectable({
  providedIn: 'root'
})
export class ParseJWTService {

  constructor() { }

  GetUserData(): Observable<TokenDataModel>{
    var token = localStorage.getItem("token");
    if(token == null || token == undefined || token === ""){
      return new Observable<TokenDataModel>(subscriber => {
        subscriber.complete();
      })
    }

    var user = new TokenDataModel();

    var data = jwt_decode(token) as any;
    console.log(data);

    user.name = data.name;
    user.surname = data.surname;
    user.email = data.email;
    user.phone = data.phone;
    user.expired = data.exp;

    return new Observable<TokenDataModel>(subscriber => {
      subscriber.next(user);
      subscriber.complete();
    })
  }
}
function jwt_decode(token: string): any {
  throw new Error('Function not implemented.');
}

