import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.css']
})
export class AddEditUserComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  @Input() user: any;
  Id: number = 0;
  Email: string = "";
  Password: string = "";
  ngOnInit(): void {
    this.Id = this.user.Id;
    this.Email = this.user.Email;
    this.Password = this.user.Password;
  }

  addUser() {
    var value = {
      Email: this.Email,
      Password: this.Password
    }
    this.service.addUser(value).subscribe(res => {
      alert(`Saccessed Add Your Email Is: ${value.Email}`);
    });
  }
  updateUser() {
    var value = {
      Id: this.Id,
      Email: this.Email,
      Password: this.Password
    }
    this.service.updateUser(value).subscribe(res => {
      alert(`Saccessed Update Your Email Is: ${value.Email}`);
    });
  }

}
