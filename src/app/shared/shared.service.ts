import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SharedService {
  readonly APIUrl = "https://localhost:44319/api";
  readonly PhotoUrl = "https://localhost:44319/Photos";
 
  constructor(private http:HttpClient) { }

  getCompanyList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Companies');
  }
  addCompany(company:any){
    return this.http.post(this.APIUrl+'/Companies', company);
  }
  updateCompany(company:any){
    return this.http.put(this.APIUrl+'/Companies', company);
  }
  deleteCompany(id:any){
    return this.http.delete(this.APIUrl+'/Companies/' + id);
  }
  addCompanyPhoto(val:any){
    return this.http.post(this.APIUrl+'/Companies/SaveFile', val)
  }
  getOfficeList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Offices');
  }
  addOffice(office:any){
    return this.http.post(this.APIUrl+'/Offices', office);
  }
  updateOffice(office:any){
    return this.http.put(this.APIUrl+'/Offices', office);
  }
  deleteOffice(id:any){
    return this.http.delete(this.APIUrl+'/Offices/' + id);
  }
  addOfficePhoto(val:any){
    return this.http.post(this.APIUrl+'/Offices/SaveFile', val)
  }
  getOfficeRooms(id:any){
    return this.http.get<any>(this.APIUrl+'/Offices/GetOfficeRooms', id);
  }

  getUserList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Users');
  }
  addUser(user:any){
    return this.http.post(this.APIUrl+'/Users', user);
  }
  loginUser(user:any){
    return this.http.post(this.APIUrl+'/Users/Login', user);
  }
  logoutUser(){
    return this.http.post(this.APIUrl+'/Users/Logout', null);
  }
  updateUser(user:any){
    return this.http.put(this.APIUrl+'/Users', user);
  }
  deleteUser(id:any){
    return this.http.delete(this.APIUrl+'/Users/' + id);
  }
  getAuthorized(){
    return this.http.get<any>(this.APIUrl+'/Users/IsAuthorized');
  }
}
