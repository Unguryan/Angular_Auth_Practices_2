import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  
  constructor(private bd: FormBuilder, private authService: AuthService){

  }

  ngOnInit() {
    this.CreateControls();
    this.CreateForm();
  }

  OnSubmit(){
    console.dir(this.loginForm);

    this.pending = true;

    this.authService.LoginUser(this.loginForm.value).subscribe(resp => {
      this.pending = false;
      if(resp.isSuccess){
        localStorage.setItem("token", resp.token);

        alert("success");
      }
      else{
        localStorage.removeItem("token");

        alert(`fail ${resp.errorMessage}`);
      }
    },
    error => {
      alert("server fail");
    },
    );

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
        console.log(element.id + this.emailSelected);

        this.emailControl.addValidators([Validators.required, Validators.email]);

        this.phoneControl.patchValue("", {emitEvent: false});
        this.phoneControl.clearValidators();
        this.phoneControl.updateValueAndValidity();
        this.phoneControl.markAsUntouched();

        console.dir(this.loginForm.controls);
        return;
      case "PhoneRadio1":
        this.emailSelected = false;
        console.log(element.id + this.emailSelected);

        this.phoneControl.addValidators([Validators.required]);

        this.emailControl.patchValue("", {emitEvent: false});
        this.emailControl.clearValidators();
        this.emailControl.updateValueAndValidity();
        this.emailControl.markAsUntouched();

        console.dir(this.loginForm.controls);
        return;
    }
  }


}
