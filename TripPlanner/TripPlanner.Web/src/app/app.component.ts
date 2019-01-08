import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TestServiceService } from './test-service.service';
import { AddTripService } from './add-trip.service';
import { Trip } from './trip.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TestServiceService]
})
export class AppComponent implements OnInit {

  public trips: Trip[];
  public tripToAdd: Trip;

  constructor(private testService: TestServiceService,
    private addTripService: AddTripService) {
  }

  public ngOnInit(): void {
    this.testService.getTrip().then(result => {
      this.trips = result;
      console.log(result);
    }).catch(error => {
    });
  }

  onSubmit(f: NgForm) {
    this.tripToAdd = new Trip();
    
    this.tripToAdd.id = f.value.id;
    this.tripToAdd.authorInformation = f.value.authorInformation;
    this.tripToAdd.fromLocation = f.value.fromLocation;
    this.tripToAdd.toLocation = f.value.toLocation;
    this.tripToAdd.hotelName = f.value.hotelName;
    this.tripToAdd.type = f.value.type;
    this.tripToAdd.estimateCost = f.value.estimateCost;

    this.addTripService.addTrip(this.tripToAdd)
      .subscribe((trip: Trip) => this.trips.push(this.tripToAdd),
        error => console.log(error));
  }

  title = 'TripPlanner';
}
