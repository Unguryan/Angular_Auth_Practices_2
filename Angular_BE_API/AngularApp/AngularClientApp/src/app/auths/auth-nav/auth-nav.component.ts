import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { ParseJWTService } from '../parse-jwt.service';
import { LogoutViewModel, TokenDataModel } from '../viewModels';

@Component({
  selector: 'app-auth-nav',
  templateUrl: './auth-nav.component.html',
  styleUrls: ['./auth-nav.component.css']
})
export class AuthNavComponent implements OnInit {

  user: TokenDataModel | undefined = undefined;

  isLogOutSuccess: boolean = false;

  logOutError: string | undefined = undefined;

  constructor(private parser: ParseJWTService,
              private auth: AuthService,
              private router: Router) {

  }
  ngOnInit() {
    this.parser.GetUserData().subscribe(resp => {
      this.user = resp;

      if(this.user?.name == undefined && 
         this.user?.surname == undefined){
          this.LogOut(false);
         }
    });
  }

  LogOut(showMessage: boolean = true) {
    if (this.user != undefined)
      this.auth.LogOut(new LogoutViewModel(this.user?.token)).subscribe(resp => {
        if(showMessage){
          if (resp.isSuccess) {
            this.isLogOutSuccess = true;
          }
          else {
            this.logOutError = resp.errorMessage;
          }
        }

        localStorage.removeItem('token');

        setTimeout(()=>{
          if(showMessage){
            this.router.navigate(["/login"]).then(() => {
              window.location.reload();
            });
          }
          else{
            window.location.reload();
          }
        }, 3000);
      })
    //this.userName = "";
  }
}
