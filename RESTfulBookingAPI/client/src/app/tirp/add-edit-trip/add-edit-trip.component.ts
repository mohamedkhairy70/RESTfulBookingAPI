import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-trip',
  templateUrl: './add-edit-trip.component.html',
  styleUrls: ['./add-edit-trip.component.css']
})
export class AddEditTripComponent implements OnInit {

  @Input() trip: any;

  Id: number = 0;
  Name: string = "";
  CityName:string = "";
  Price:number = 0;
  CreationDate: Date = new Date();
  PhotoFilePath: string = "";
  ImageUrl: string = "anonymous.png";

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.leadTrip();
  }

  leadTrip() {
    this.service.getTripList().subscribe(data => {
      this.Id = this.trip.Id;
      this.Name = this.trip.Name;
      this.CityName = this.trip.CityName;
      this.CreationDate = this.trip.CreationDate;
      this.ImageUrl = this.trip.ImageUrl;
      this.PhotoFilePath = this.service.PhotoUrl + this.trip.ImageUrl;
    });
  }

  addTrip() {
    var value = {
      Name: this.Name,
      CityName: this.CityName,
      CreationDate: this.CreationDate,
      ImageUrl: this.ImageUrl
    };
    this.service.addTrip(value).subscribe(res => {
      alert("Successed Add Your Name:" + value.Name);
    });
  }

  updateTrip() {
    var value = {
      Id: this.Id,
      Name: this.Name,
      CityName: this.CityName,
      CreationDate: this.CreationDate,
      ImageUrl: this.ImageUrl
    };
    this.service.updateTrip(value).subscribe(res => {
      alert("Successed Update Your Name:" + value.Name);
    });
  }

  uploadPhoto(event: any) {
    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('uploadedFile', file, file.name);
    this.service.uploadPhoto(formData).subscribe((data: any) => {
      this.ImageUrl = data.toString();
      this.PhotoFilePath = this.service.PhotoUrl + this.ImageUrl;
    });
  }
}
