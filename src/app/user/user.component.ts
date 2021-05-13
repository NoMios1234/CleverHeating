import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  LoginForm:boolean = true;
  RegForm:boolean = false;

  constructor(private location: Location, private router: Router) {}
   
  ngOnInit(): void {
    if(localStorage.getItem('token') == null){
      if (this.location.path() == '/user'){
        this.router.navigateByUrl('/user/login');
      }
      if(this.location.path() == '/user/registration'){
        this.RegForm = true;
        this.LoginForm = false;
      }
      if(this.location.path() == '/user/login'){
        this.RegForm = false;
        this.LoginForm = true;
      }   
    }
    else if (localStorage.getItem('token') != null)
    {
      this.RegForm = false;
      this.LoginForm = false;
      this.router.navigateByUrl('/home');
    }
  }
  login(){
    this.LoginForm = true;
    this.RegForm = false;
  }
  registration(){
    this.RegForm = true;
    this.LoginForm = false;
  }
}
