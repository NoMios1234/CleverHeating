import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient  } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = "https://localhost:44319/api";

  loginForm  = this.fb.group({
    Email : [''],
    Password : ['']
  });

  formModel = this.fb.group({
    Email : ['', [Validators.email, Validators.required]],
    FirstName : [''],
    SecondName : [''],
    Patronymic : [''],
    PhoneNumber: ['', Validators.pattern("[0-9]{3}[0-9]{3}[0-9]{4}")],
    Passwords : this.fb.group({
      Password : ['', [Validators.required, Validators.minLength(8)]],
      PasswordConfirm : ['', Validators.minLength(8)]
    }, { validator: this.comparePasswords })
    
  });
  
  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('PasswordConfirm');
    if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password')?.value != confirmPswrdCtrl?.value)
        confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl?.setErrors(null);
    }
  }

  register() {
    var body = {
      Email: this.formModel.value.Email,
      FirstName: this.formModel.value.FirstName,
      SecondName: this.formModel.value.SecondName,
      Patronymic: this.formModel.value.Patronymic,
      PhoneNumber: this.formModel.value.PhoneNumber,
      Password: this.formModel.value.Passwords.Password,
      PasswordConfirm: this.formModel.value.Passwords.PasswordConfirm
    };
    console.log(body);
    return this.http.post(this.BaseURI + '/users/register', body);
  }

  login() {
    var body = {
      
      Email: this.loginForm.value.Email,
      Password: this.loginForm.value.Password
    };
    console.log(body);
    return this.http.post(this.BaseURI + '/users/login', body);
  }
  
  getUserList():Observable<any[]>{
    return this.http.get<any>(this.BaseURI+'/Users');
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/users/profile');
  }
}
