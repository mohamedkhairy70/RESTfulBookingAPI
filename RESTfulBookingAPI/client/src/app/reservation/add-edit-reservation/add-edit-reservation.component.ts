import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-reservation',
  templateUrl: './add-edit-reservation.component.html',
  styleUrls: ['./add-edit-reservation.component.css']
})
export class AddEditReservationComponent implements OnInit {

  @Input() reservation: any;

  Id: number = 0;
  ReservedBy: string = "";
  CustomerName:string = "";
  ReservationDate: Date = new Date();
  CreationDate: Date = new Date();
  Notes: string = "";
  TripName: string = "";

  tripList: any = [];
  userList: any = [];

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.leadReservation();
  }

  leadReservation() {
    this.service.getTripListOfNames().subscribe(data => {
      this.tripList = data;
      this.Id = this.reservation.Id;
      this.ReservedBy = this.reservation.ReservedBy;
      this.CustomerName = this.reservation.CustomerName;
      this.ReservationDate = this.reservation.ReservationDate;
      this.CreationDate = this.reservation.CreationDate;
      this.Notes = this.reservation.Notes;
      this.TripName = this.reservation.TripName;
    });
    this.service.getUserListOfNames().subscribe(data => {
      this.userList = data;
    });
  }

  addReservation() {
    var value = {
      ReservedBy: this.ReservedBy,
      CustomerName:this.CustomerName,
      ReservationDate: this.ReservationDate,
      CreationDate: this.CreationDate,
      Notes: this.Notes,
      TripName: this.TripName
    };
    this.service.addReservation(value).subscribe(res => {
      alert("Successed Add Your Date:" + value.ReservationDate);
    });
  }

  updateReservation() {
    var value = {
      Id: this.Id,
      ReservedBy: this.ReservedBy,
      CustomerName:this.CustomerName,
      ReservationDate: this.ReservationDate,
      CreationDate: this.CreationDate,
      Notes: this.Notes,
      TripName: this.TripName
    };
    this.service.updateReservation(value).subscribe(res => {
      alert("Successed Update Your Name:" + value.ReservationDate);
    });
  }
}
