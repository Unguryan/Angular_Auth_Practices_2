import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";

import { AuthsRoutingModule } from './auths-routing.module';
import { AuthNavComponent } from './auth-nav/auth-nav.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AuthNavComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    CommonModule,
    AuthsRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
    AuthNavComponent,
    LoginComponent,
    RegisterComponent
  ]
})
export class AuthsModule { }
