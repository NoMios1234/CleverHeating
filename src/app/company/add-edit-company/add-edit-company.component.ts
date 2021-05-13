import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.css']
})
export class AddEditCompanyComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() company:any;
  Id:string;
  CompanyName:string;
  CompanyAddress:string;
  CompanyPhoneNumber:string;
  CompanyDescription:string;
  PhotoFileName:string;
  PhotoFilePath:string;


  ngOnInit(): void {
    this.loadCompanyList();
  }

  loadCompanyList(){
    this.Id=this.company.Id;
    this.CompanyName=this.company.CompanyName;
    this.CompanyAddress=this.company.CompanyAddress;
    this.CompanyPhoneNumber=this.company.CompanyPhoneNumber;
    this.CompanyDescription=this.company.CompanyDescription;
    this.PhotoFileName=this.company.PhotoFileName;
    this.PhotoFilePath=this.service.PhotoUrl+'/Company/'+this.PhotoFileName;   
  }

  addCompany(){
    var val = {
      Id:this.Id,
      CompanyName:this.CompanyName,               
      CompanyAddress:this.CompanyAddress,
      CompanyPhoneNumber:this.CompanyPhoneNumber,           
      CompanyDescription:this.CompanyDescription,       
      PhotoFileName:this.PhotoFileName
    };
    this.service.addCompany(val).subscribe(res=>{
      alert('Added');
    });
  }

  updateCompany(){
    var val = {
      Id:this.Id,
      CompanyName:this.CompanyName,               
      CompanyAddress:this.CompanyAddress,
      CompanyPhoneNumber:this.CompanyPhoneNumber,           
      CompanyDescription:this.CompanyDescription,       
      PhotoFileName:this.PhotoFileName
    };

    this.service.updateCompany(val).subscribe(res=>{
      alert('Updated');
    });
  }

  uploadPhoto(event: any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);
    this.service.addCompanyPhoto(formData).subscribe((data:any)=>{
      console.log(data);
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+'/Company/'+this.PhotoFileName;
    })
  }
}
