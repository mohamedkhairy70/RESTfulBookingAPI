import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly ApiUrl: string = "http://localhost:61831/api";
  readonly PhotoUrl: string = "http://localhost:61831/Photos/";

  constructor(private http: HttpClient) { }
  
  //Get All Data User From Api
  //http://localhost:61831/api/User
  getUserList(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/User');
  }

  //Get All Data UserListOfNames From Api
  //http://localhost:61831/api/User
  getUserListOfNames(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/User/GetNames');
  }

  //Get Data of One User From Api
  //http://localhost:61831/api/User/5
  getUserOneById(val:number): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/User/'+val);
  }

  //Add One New User By Api
  //http://localhost:61831/api/User
  addUser(val:any): Observable<[]>{
    return this.http.post<any>(this.ApiUrl +'/User',val);
  }

  //Edit One User IsExists By Api
  //http://localhost:61831/api/User
  updateUser(val:any): Observable<[]>{
    return this.http.put<any>(this.ApiUrl +'/User',val);
  }

  //Delete One User IsExists By Api
  //http://localhost:61831/api/User
  deleteUser(val:number): Observable<[]>{
    return this.http.delete<any>(this.ApiUrl +'/User/'+val);
  }

  //Get All Data Trip From Api
  //http://localhost:61831/api/Trip
  getTripList(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Trip');
  }

  //Get Data of One User From Api
  //http://localhost:61831/api/User/5
  getTripOneById(val:number): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Trip/'+val);
  }

  //Get All Data TripListOfNames From Api
  //http://localhost:61831/api/Trip
  getTripListOfNames(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Trip/GetNames');
  }

  //Add One New Trip By Api
  //http://localhost:61831/api/Trip
  addTrip(val:any): Observable<[]>{
    return this.http.post<any>(this.ApiUrl +'/Trip',val);
  }

  //Edit One Trip IsExists By Api
  //http://localhost:61831/api/Trip
  updateTrip(val:any): Observable<[]>{
    return this.http.put<any>(this.ApiUrl +'/Trip',val);
  }

  //Delete One Trip IsExists By Api
  //http://localhost:61831/api/Trip
  deleteTrip(val:number): Observable<[]>{
    return this.http.delete<any>(this.ApiUrl +'/Trip/'+val);
  }

  //Add Photo for Trip is Exists From Api
  //http://localhost:26713/api/Trip/SaveFile
  uploadPhoto(value: any){
    return this.http.post(this.ApiUrl + '/Trip/SaveFile', value);
  }

  //Get All Data Reservation From Api
  //http://localhost:61831/api/Reservation
  getReservationList(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Reservations');
  }

  //Get Data of One Reservation From Api
  //http://localhost:61831/api/Reservation/5
  getReservationOneById(val:number): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Reservations/'+val);
  }

  //Get All Data ReservationListOfNames From Api
  //http://localhost:61831/api/Reservation
  getReservationListOfNames(): Observable<[]>{
    return this.http.get<any>(this.ApiUrl +'/Reservations/GetNames');
  }

  //Add One New Reservation By Api
  //http://localhost:61831/api/Reservation
  addReservation(val:any): Observable<[]>{
    return this.http.post<any>(this.ApiUrl +'/Reservations',val);
  }

  //Edit One Reservation IsExists By Api
  //http://localhost:61831/api/Reservation
  updateReservation(val:any): Observable<[]>{
    return this.http.put<any>(this.ApiUrl +'/Reservations',val);
  }

  //Delete One Reservation IsExists By Api
  //http://localhost:61831/api/Reservation
  deleteReservation(val:number): Observable<[]>{
    return this.http.delete<any>(this.ApiUrl +'/Reservations/'+val);
  }
  
}
