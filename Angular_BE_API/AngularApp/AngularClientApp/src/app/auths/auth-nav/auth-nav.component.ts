import { Component } from '@angular/core';

@Component({
  selector: 'app-auth-nav',
  templateUrl: './auth-nav.component.html',
  styleUrls: ['./auth-nav.component.css']
})
export class AuthNavComponent {

  userName: string;

  constructor(){
    
  }

  LoginTest(){
    this.userName = "USERNAME";
  }
  LogOut(){
    this.userName = "";
  }
}
