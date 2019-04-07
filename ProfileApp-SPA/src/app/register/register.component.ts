import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '_services/AuthService';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};
  @Input() valuesFromHome: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.auth.register(this.model).subscribe(() => {
      console.log('Register SuccessFully');
    },
    error => {
      console.log(error);
    });
  console.log(this.model);
  }

  cancle() {
    this.cancelRegister.emit(false);
  }

}
