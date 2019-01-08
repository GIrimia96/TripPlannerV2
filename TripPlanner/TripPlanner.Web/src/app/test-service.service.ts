import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const BaseRoute: string = 'http://localhost/TripPlanner';

@Injectable({
  providedIn: 'root'
})

export class TestServiceService {

  constructor(private httpclient: HttpClient) { }

  public getTrip(): Promise<any> {
    let route = `${BaseRoute}/api/trip`;
    
    let x = this.httpclient.get(route);
    return x.toPromise();
  }
}



