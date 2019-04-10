import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '_services/AuthService';
import { ErrorIntercetorService } from '_services/error.intercetor.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};
  @Input() valuesFromHome: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(private auth: AuthService, private errors: ErrorIntercetorService) { }

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
