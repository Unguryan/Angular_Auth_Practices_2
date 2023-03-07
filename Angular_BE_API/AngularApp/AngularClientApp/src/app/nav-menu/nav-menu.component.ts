import { Component } from '@angular/core';
import { ParseJWTService } from '../auths/parse-jwt.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  user: boolean = false;

  constructor(private parser: ParseJWTService) {

  }
  ngOnInit() {
    this.parser.GetUserData().subscribe(resp => {
      if(resp?.name != undefined && 
         resp?.surname != undefined &&
         resp?.token != undefined){
           this.user = true;
         }
    });
  }
}
