import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthsModule } from './auths/auths.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,


    AppRoutingModule,
    AuthsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
