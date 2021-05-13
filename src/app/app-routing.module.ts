import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

import { CompanyComponent } from './company/company.component';
import { HomeComponent } from './home/home.component';
import { OfficeComponent } from './office/office.component';
import { LoginComponent } from './user/login/login.component';
import { ProfileComponent } from './user/profile/profile.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  { path:'',redirectTo:'/user/login', pathMatch:'full'},
  { path:'company', component:CompanyComponent, canActivate:[AuthGuard] },
  { path:'office', component:OfficeComponent, canActivate:[AuthGuard] },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }     
    ]
  },
  { path:'home', component: HomeComponent, canActivate:[AuthGuard] },
  { path: 'user/profile', component: ProfileComponent, canActivate:[AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
