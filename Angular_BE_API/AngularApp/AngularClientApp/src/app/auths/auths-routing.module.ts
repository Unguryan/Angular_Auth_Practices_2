import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { AuthedGuard } from './guards/authed.guard';
import { UnauthedGuard } from './guards/unauthed.guard';
import { HomeComponent } from './home/home.component';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: "",
   component: HomeComponent},
  {path: "login",
   component: LoginComponent,
   canActivate: [UnauthedGuard]},
  {path: "register", 
   component: RegisterComponent,
   canActivate: [UnauthedGuard]},
   {path: "admin", 
   component: AdminPanelComponent,
   canActivate: [AuthedGuard]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthsRoutingModule { }
