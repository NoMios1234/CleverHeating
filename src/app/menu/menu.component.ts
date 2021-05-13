import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  UserAuth:any;

  constructor(private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.UserAuth = true;
    if (localStorage.getItem('token') == null)
      this.UserAuth = false;
  }

  goProfile(){
    this.router.navigate(['/user/profile']);
  }

  onLogout() {
    if(confirm('Are you logout?')){
      this.UserAuth = false;
      localStorage.removeItem('token');
      window.location.reload();
    }
  }  

}
