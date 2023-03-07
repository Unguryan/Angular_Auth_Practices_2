import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../env';

import { LoginResultViewModel,
         LoginViewModel,
         LogoutResultViewModel,
         LogoutViewModel,
         RegisterResultViewModel,
         RegisterViewModel} from './viewModels';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  RegisterUser(vm: RegisterViewModel): Observable<RegisterResultViewModel>{
    var url = environment.Backend_API + "auth/register";
    return this.http.post<RegisterResultViewModel>(url, vm);
  }

  LoginUser(vm: LoginViewModel): Observable<LoginResultViewModel>{
    var url = environment.Backend_API + "auth/login";
    return this.http.post<LoginResultViewModel>(url, vm);
  }

  LogOut(vm: LogoutViewModel): Observable<LogoutResultViewModel>{
    var url = environment.Backend_API + "auth/logout";
    return this.http.post<LogoutResultViewModel>(url, vm);
  } 
}
