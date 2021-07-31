import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-trip',
  templateUrl: './show-trip.component.html',
  styleUrls: ['./show-trip.component.css']
})
export class ShowTripComponent implements OnInit {

  tripList: any = [];
  ModalTitle: string = "";
  Trip: any;
  ActivateAddEditTripComp: boolean = false;

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshTripList();
  }

  refreshTripList() {
    this.service.getTripList().subscribe(res => {
      this.tripList = res;
    })
  }
  addClick() {
    this.Trip = {
      Id:0,
      Name: "",
      CityName: "",
      Price: 0,
      CreationDate: new Date(),
      ImageUrl:"anonymous.png"
    }
    this.ModalTitle = "Add Trip";
    this.ActivateAddEditTripComp = true;
  }
  closeClick() {
    this.ActivateAddEditTripComp = false;
    this.refreshTripList();
  }

  editClick(value:any) {
    this.Trip = value;
    this.ModalTitle = "Update Trip";
    this.ActivateAddEditTripComp = true;
  }

  deleteClick(value: any) {
    if (confirm("Are You Sure??")) {
      this.service.deleteTrip(value.Id).subscribe(res => {
        alert(value.Name)
      });
    }
    this.ActivateAddEditTripComp = false;
    this.refreshTripList();
  }
}
