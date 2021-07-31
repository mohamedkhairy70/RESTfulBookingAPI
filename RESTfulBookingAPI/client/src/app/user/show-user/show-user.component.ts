import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  styleUrls: ['./show-user.component.css']
})
export class ShowUserComponent implements OnInit {

  userList: any = [];
  User: any;
  ActivateAddEditUserComp: boolean = false;
  ModalTitle: string = "";
  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshDataOfList();
  }

  refreshDataOfList() {
    this.service.getUserList().subscribe(data => {
      this.userList = data;
    });
  }

  addClick() {
    this.User = {
      Id: 0,
      Email: "",
      Password: ""
    };
    this.ModalTitle = "Add New User";
    this.ActivateAddEditUserComp = true;
  }

  closeClick() {
    this.ModalTitle = "";
    this.ActivateAddEditUserComp = false;
    this.refreshDataOfList();
  }

  editClick(value:any) {
    this.User = value;
    this.ModalTitle = "Edit User";
    this.ActivateAddEditUserComp = true;
  }
  deleteClick(value: any) {
    if (confirm("Are You Sure??")) {
      this.service.deleteUser(value.Id).subscribe(res => {
        alert("Done Delete"+value.Email.toString());
        this.refreshDataOfList();
      });
    }
  }
}
