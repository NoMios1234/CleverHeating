import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-show-office',
  templateUrl: './show-office.component.html',
  styleUrls: ['./show-office.component.css']
})
export class ShowOfficeComponent implements OnInit {

  constructor(private service:SharedService) { }

  OfficeList:any[];
  ModalTitle:string;
  ActivateAddEditOffice:boolean=false;
  office:any;
  OfficePathImage=this.service.PhotoUrl + '/Office/';

  ngOnInit(): void {
    this.refreshOfficetList();
  }
  addClick(){
    this.office={
      Id:0,
      OfficeName:"",
      OfficeAddress:"",
      OfficePhoneNumber:"",
      OfficeDescription:"",
      PhotoFileName:"default_office_image.png"     
    }
    this.ModalTitle="Add Office";
    this.ActivateAddEditOffice=true;
  }

  editClick(item: any){
    console.log(item);
    this.office=item;
    this.ModalTitle="Edit Office";
    this.ActivateAddEditOffice=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      console.log(item);
      this.service.deleteOffice(item.Id).subscribe(data =>{
        alert(data.toString());
        this.refreshOfficetList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditOffice=false;
    this.refreshOfficetList();
  }

  refreshOfficetList(){ 
    this.service.getOfficeList().subscribe(data=>{
      data.forEach(element => {
        element.PhotoFileFullPath = this.OfficePathImage + element.PhotoFileName;
      });
      this.OfficeList = data;
    });
  }
}
