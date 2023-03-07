import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  regForm: FormGroup;
  
  firstNameControl: FormControl;
  lastNameControl: FormControl;
  emailControl: FormControl;
  phoneControl: FormControl;
  passwordControl: FormControl;
  passwordConfirmControl: FormControl;

  pending: boolean = false;

  regError: string;
  isRegisterSuccess: boolean = false;

  constructor(private bd: FormBuilder, 
              private authService: AuthService,
              private router: Router){

  }

  ngOnInit(){
    this.CreateControls();
    this.CreateForm();
  }

  CreateControls() {
    this.firstNameControl = this.bd.control('', [Validators.required]);
    this.lastNameControl = this.bd.control('', [Validators.required]);
    this.emailControl = this.bd.control('', [Validators.required, Validators.email]);
    this.phoneControl = this.bd.control('', [Validators.required]);
    this.passwordControl = this.bd.control('', [Validators.required, Validators.minLength(8)]);
    this.passwordConfirmControl = this.bd.control('', [Validators.required, Validators.minLength(8)]);
    this.passwordConfirmControl.addValidators(this.CreateCompareValidator(this.passwordControl, this.passwordConfirmControl));
  }
  
  CreateForm() {
    this.regForm = this.bd.group({
      name: this.firstNameControl,
      surname: this.lastNameControl,
      email: this.emailControl,
      phone: this.phoneControl,
      password: this.passwordControl,
      passwordConfirm: this.passwordConfirmControl,
    });
  }

  OnSubmit(){
    this.pending = true;

    this.authService.RegisterUser(this.regForm.value).subscribe(resp => {
      this.pending = false;
      if(resp.isSuccess){
        localStorage.setItem('token', resp.token);
        
        this.isRegisterSuccess = true;
        setTimeout(()=>{
          this.router.navigate(["/"]).then(()=>{
            window.location.reload();
          });
        }, 5000);
      }
      else{
        localStorage.removeItem('token');
        this.regError = resp.errorMessage!;
      }
    },
    error => {
      this.pending = false;
      this.regError = "server fail";
      setTimeout(()=>{
        window.location.reload();
      }, 3000);
    });
  }

  CreateCompareValidator(controlOne: AbstractControl, controlTwo: AbstractControl) {
    return () => {
    if (controlOne.value !== controlTwo.value)
      return { matched: 'Passwords do not match' };
    return null;
  };

}
}
