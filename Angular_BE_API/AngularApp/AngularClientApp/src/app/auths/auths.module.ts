import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";

import { AuthsRoutingModule } from './auths-routing.module';
import { AuthNavComponent } from './auth-nav/auth-nav.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    AuthNavComponent,
    LoginComponent,
    RegisterComponent,
    AdminPanelComponent,
    HomeComponent,
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
