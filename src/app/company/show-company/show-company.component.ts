import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-show-company',
  templateUrl: './show-company.component.html',
  styleUrls: ['./show-company.component.css']
})
export class ShowCompanyComponent implements OnInit {

  constructor(private service:SharedService) { }

  CompanyList:any[];
  ModalTitle:string;
  ActivateAddEditCompany:boolean=false;
  company:any;
  companyPathImage=this.service.PhotoUrl + '/Company/';

  ngOnInit(): void {
    this.refreshCompanytList();
  }
  addClick(){
    this.company={
      Id:0,
      CompanyName:"",
      CompanyAddress:"",
      CompanyPhoneNumber:"",
      CompanyDescription:"",
      PhotoFileName:"default_company_image.png"     
    }
    this.ModalTitle="Add Company";
    this.ActivateAddEditCompany=true;
  }

  editClick(item: any){
    console.log(item);
    this.company=item;
    this.ModalTitle="Edit Company";
    this.ActivateAddEditCompany=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      console.log(item);
      this.service.deleteCompany(item.Id).subscribe(data =>{
        alert(data.toString());
        this.refreshCompanytList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditCompany=false;
    this.refreshCompanytList();
  }

  refreshCompanytList(){ 
    this.service.getCompanyList().subscribe(data=>{
      data.forEach(element => {
        element.PhotoFileFullPath = this.companyPathImage + element.PhotoFileName;
      });
      this.CompanyList = data;
    });
  }
}
