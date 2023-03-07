import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ParseJWTService } from '../parse-jwt.service';

@Injectable({
  providedIn: 'root'
})
export class UnauthedGuard implements CanActivate {
  constructor(private parser: ParseJWTService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      var res = false;
      this.parser.GetUserData().subscribe(resp =>{
        if(resp == undefined){
          res = true;
        }
  
        if(resp?.name == undefined && 
          resp?.surname == undefined){
          res = true;
          }
      });
  
      return res;
  }
  
}
