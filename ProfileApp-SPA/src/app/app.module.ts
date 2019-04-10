import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import {FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorIntercetorService } from '_services/error.intercetor.service';
import { AuthService } from '_services/AuthService';
import { AlertifyService } from '_services/alertify.service';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot()
   ],
   providers: [ AuthService , ErrorIntercetorService, AlertifyService ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
