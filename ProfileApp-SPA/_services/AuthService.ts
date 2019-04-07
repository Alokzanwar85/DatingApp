import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseurl = 'http://localhost:5000/api/auth/';
  token: any;
  constructor(private httpClient: HttpClient) {
  }
  login(model: any) {
    return this.httpClient.post(this.baseurl + 'Login', model).pipe(map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
      }
    }));
  }

  register(model: any) {
    return this.httpClient.post(this.baseurl + 'Register', model);
  }
}
