import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  exportAs: "RegistrationComponent"
})
export class RegistrationComponent implements OnInit {

  constructor(public service:UserService,  private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();  
    if (localStorage.getItem('token') != null)
    this.router.navigateByUrl('/home'); 
  }
  onSubmit(){ 
    this.service.register().subscribe(
      (res: any) => {
        if (res.Succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.');
        } else {
          res.Errors.forEach((element: { Code: any; Description: string | undefined; }) => {
            this.toastr.error(element.Description,'Registration failed.');
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
