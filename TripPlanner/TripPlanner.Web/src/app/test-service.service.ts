import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const BaseRoute: string = 'http://localhost/TripPlanner';

@Injectable({
  providedIn: 'root'
})

export class TestServiceService {

  constructor(private httpclient: HttpClient) { }

  public getTrip(): Observable<any> {
    let route = `${BaseRoute}/api/trip`;
    
    return this.httpclient.get(route);
  }
}



