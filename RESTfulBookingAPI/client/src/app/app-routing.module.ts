import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationComponent } from './reservation/reservation.component';
import { TirpComponent } from './tirp/tirp.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: "user", component: UserComponent },
  { path: "trip", component: TirpComponent },
  { path: "reservation", component: ReservationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
