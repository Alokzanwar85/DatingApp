import { Component, OnInit } from '@angular/core';
import { AuthService } from '_services/AuthService';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  isLoggedIn = false;
  constructor(private authservice: AuthService) { }

  ngOnInit() {
  }

  Login()  {
    this.authservice.login(this.model).subscribe(next => {
      console.log('logged in successfully');
      this.isLoggedIn = true;
    },
    error => {
        console.log('error');
    }
    );
    console.log(this.model);

  }

}
