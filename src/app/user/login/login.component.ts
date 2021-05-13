import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.loginForm.reset();
    if (localStorage.getItem('token') != null)
    this.router.navigateByUrl('/home'); 
  }

  onSubmit(){
    this.service.login().subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        window.location.reload();
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }
}
