import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Trip } from './trip.model';
import { Observable } from 'rxjs';

const BaseRoute: string = 'http://localhost/TripPlanner';

@Injectable({
  providedIn: 'root'
})
export class AddTripService {

  constructor(private http: HttpClient) { }

  public addTrip(trip: Trip): Observable<Trip> {
    let route = `${BaseRoute}/api/trip`;

    return this.http.post<Trip>(route, trip);
  }
}
