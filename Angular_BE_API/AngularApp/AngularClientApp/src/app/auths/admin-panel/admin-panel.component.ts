import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { ParseJWTService } from '../parse-jwt.service';
import { TokenDataModel } from '../viewModels';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  
  user: TokenDataModel | undefined = undefined;

  isLogOutSuccess: boolean = false;

  logOutError: string | undefined = undefined;

  constructor(private parser: ParseJWTService,
              private auth: AuthService,
              private router: Router){
                
              }


  ngOnInit() {
    this.parser.GetUserData().subscribe(resp => {
      this.user = resp;
    });
  }


}
