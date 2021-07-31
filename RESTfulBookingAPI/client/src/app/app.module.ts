import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { AddEditUserComponent } from './user/add-edit-user/add-edit-user.component';
import { ShowUserComponent } from './user/show-user/show-user.component';
import { TirpComponent } from './tirp/tirp.component';
import { AddEditTripComponent } from './tirp/add-edit-trip/add-edit-trip.component';
import { ShowTripComponent } from './tirp/show-trip/show-trip.component';
import { ReservationComponent } from './reservation/reservation.component';
import { AddEditReservationComponent } from './reservation/add-edit-reservation/add-edit-reservation.component';
import { ShowReservationComponent } from './reservation/show-reservation/show-reservation.component';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    AddEditUserComponent,
    ShowUserComponent,
    TirpComponent,
    AddEditTripComponent,
    ShowTripComponent,
    ReservationComponent,
    AddEditReservationComponent,
    ShowReservationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
