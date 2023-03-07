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
      console.log(this.user);
    });
  }

  LogOut() {
    if (this.user != undefined)
      this.auth.LogOut(new LogoutViewModel(this.user?.token)).subscribe(resp => {
        if (resp.isSuccess) {
          this.isLogOutSuccess = true;
        }
        else {
          this.logOutError = resp.errorMessage;
        }

        localStorage.removeItem("token");
        console.log("nav - remove");

        setTimeout(()=>{
          this.router.navigate(["login"]);
          window.location.reload();
        }, 3000);
      })
    //this.userName = "";
  }
}
