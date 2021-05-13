import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-add-edit-office',
  templateUrl: './add-edit-office.component.html',
  styleUrls: ['./add-edit-office.component.css']
})
export class AddEditOfficeComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() office:any;
  Id:string;
  OfficeName:string;
  OfficeAddress:string;
  OfficePhoneNumber:string;
  OfficeDescription:string;
  PhotoFileName:string;
  PhotoFilePath:string;


  ngOnInit(): void {
    this.loadOfficeList();
  }

  loadOfficeList(){
    this.Id=this.office.Id;
    this.OfficeName=this.office.OfficeName;
    this.OfficeAddress=this.office.OfficeAddress;
    this.OfficePhoneNumber=this.office.OfficePhoneNumber;
    this.OfficeDescription=this.office.OfficeDescription;
    this.PhotoFileName=this.office.PhotoFileName;
    this.PhotoFilePath=this.service.PhotoUrl+'/Office/'+this.PhotoFileName;   
  }

  addOffice(){
    var val = {
      Id:this.Id,
      OfficeName:this.OfficeName,               
      OfficeAddress:this.OfficeAddress,
      OfficePhoneNumber:this.OfficePhoneNumber,                 
      PhotoFileName:this.PhotoFileName
    };
    this.service.addOffice(val).subscribe(res=>{
      alert('Added');
    });
  }

  updateOffice(){
    var val = {
      Id:this.Id,
      OfficeName:this.OfficeName,               
      OfficeAddress:this.OfficeAddress,
      OfficePhoneNumber:this.OfficePhoneNumber,           
      OfficeDescription:this.OfficeDescription,       
      PhotoFileName:this.PhotoFileName
    };

    this.service.updateOffice(val).subscribe(res=>{
      alert('Updated');
    });
  }

  uploadPhoto(event: any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);
    this.service.addOfficePhoto(formData).subscribe((data:any)=>{
      console.log(data);
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+'/Office/'+this.PhotoFileName;
    })
  }
}
