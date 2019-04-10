import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {JwtHelperService} from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseurl = 'http://localhost:5000/api/auth/';
  token: any;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  constructor(private httpClient: HttpClient) {
  }
  login(model: any) {
    return this.httpClient.post(this.baseurl + 'Login', model).pipe(map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
        console.log(this.decodedToken);
      }
    }));
  }

  register(model: any) {
    return this.httpClient.post(this.baseurl + 'Register', model);
  }

  LoggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  GetUserName(token: string)  {
       this.decodedToken = this.jwtHelper.decodeToken(token);
  }
}
