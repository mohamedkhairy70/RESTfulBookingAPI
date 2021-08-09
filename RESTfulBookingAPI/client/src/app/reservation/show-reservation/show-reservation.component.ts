import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-reservation',
  templateUrl: './show-reservation.component.html',
  styleUrls: ['./show-reservation.component.css']
})
export class ShowReservationComponent implements OnInit {

  reservationList: any = [];
  ModalTitle: string = "";
  Reservation: any;
  ActivateAddEditReservationComp: boolean = false;

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshReservationList();
  }

  refreshReservationList() {
    this.service.getReservationList().subscribe(res => {
      this.reservationList = res;
    })
  }
  addClick() {
    this.Reservation = {
      Id: 0,
      ReservedBy: "",
      CustomerName: "",
      ReservationDate: new Date(),
      CreationDate: new Date(),
      Notes: "",
      TripName: ""
    }
    this.Reservation.Id = 0;
    this.ModalTitle = "Add Reservation";
    this.ActivateAddEditReservationComp = true;
  }
  closeClick() {
    this.ActivateAddEditReservationComp = false;
    this.refreshReservationList();
  }

  editClick(value:any) {
    this.Reservation = value;
    this.ModalTitle = "Update Reservation";
    this.ActivateAddEditReservationComp = true;
  }

  deleteClick(value: any) {
    if (confirm("Are You Sure??")) {
      this.service.deleteReservation(value.Id).subscribe(res => {
        alert(res.toString());
        this.refreshReservationList();
      });
    }
    this.ActivateAddEditReservationComp = false;
    
  }
}
