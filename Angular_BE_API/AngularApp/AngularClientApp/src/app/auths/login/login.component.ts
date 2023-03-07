import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  
  emailControl: FormControl;
  phoneControl: FormControl;
  passwordControl: FormControl;
  rememberMeControl: FormControl;

  emailSelected: boolean = true;

  pending: boolean = false;

  loginError: string;
  isLoginSuccess: boolean = false;
  
  constructor(private bd: FormBuilder, 
              private authService: AuthService,
              private router: Router){

  }

  ngOnInit() {
    this.CreateControls();
    this.CreateForm();
  }

  OnSubmit(){
    this.pending = true;

    this.authService.LoginUser(this.loginForm.value).subscribe(resp => {
      this.pending = false;
      if(resp.isSuccess){
        localStorage.setItem("token", resp.token);
        
        this.isLoginSuccess = true;
        setTimeout(()=>{
          this.router.navigate(["/"]);
          window.location.reload();
        }, 5000);
      }
      else{
        localStorage.removeItem("token");
        console.log("login - remove");
        this.loginError = resp.errorMessage!;
      }
    },
    error => {
      this.pending = false;
      this.loginError = "server fail";
      setTimeout(()=>{
        window.location.reload();
      }, 3000);
    });
  }

  CreateControls() {
    this.emailControl = this.bd.control('', [Validators.required, Validators.email]);
    this.phoneControl = this.bd.control('');
    this.passwordControl = this.bd.control('', [Validators.required, Validators.minLength(8)]);
    this.rememberMeControl = this.bd.control('');
  }

  CreateForm() {
    this.loginForm = this.bd.group({
      email: this.emailControl,
      phone: this.phoneControl,
      password: this.passwordControl,
      rememberMe: this.rememberMeControl,
    });
  }

  ChangedHandler(event: Event) {
    var element = event?.target as HTMLInputElement;
    switch(element.id){
      case "EmailRadio1":
        this.emailSelected = true;
        this.emailControl.addValidators([Validators.required, Validators.email]);
        this.phoneControl.patchValue("", {emitEvent: false});
        this.phoneControl.clearValidators();
        this.phoneControl.updateValueAndValidity();
        this.phoneControl.markAsUntouched();

        return;
      case "PhoneRadio1":
        this.emailSelected = false;
        this.phoneControl.addValidators([Validators.required]);
        this.emailControl.patchValue("", {emitEvent: false});
        this.emailControl.clearValidators();
        this.emailControl.updateValueAndValidity();
        this.emailControl.markAsUntouched();
        return;
    }
  }


}
