import { Component, OnInit } from '@angular/core';
import { AuthService } from '_services/AuthService';
import { AlertifyService } from '_services/alertify.service';
import { tokenKey } from '@angular/core/src/view';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['../nav/nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  isLoggedIn = false;
  constructor(private authservice: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {

    if (this.loggedIn())    {
      this.authservice.GetUserName(localStorage.getItem('token'));
      this.isLoggedIn = true;
    }

  }

  Login()  {
    this.authservice.login(this.model).subscribe(next => {
      console.log('logged in successfully');
      this.alertify.success('logged in successfully');
      this.isLoggedIn = true;
    },
    error => {
        console.log('error');
        this.alertify.error('Failed to Login');
    }
    );
    console.log(this.model);

  }

  Logout()  {
    localStorage.removeItem('token');
    this.isLoggedIn = false;
    this.alertify.message('Logged Out Successfully');
  }

  loggedIn()  {
    if (this.authservice.LoggedIn())    {
    const token = localStorage.getItem('token');
    return !!token;
    }
  }
}
