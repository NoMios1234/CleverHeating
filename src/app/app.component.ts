import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor() { }

  UserForm:boolean = true;

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.UserForm = false;
  }
  title = 'SmartWorkApp';
}
