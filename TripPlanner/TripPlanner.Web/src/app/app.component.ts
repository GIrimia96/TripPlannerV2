import { Component, OnInit } from '@angular/core';
import { TestServiceService } from './test-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TestServiceService]
})
export class AppComponent implements OnInit {

  public locations: any;

  constructor(private testService: TestServiceService) {
  }

  public ngOnInit(): void {
    console.log(this.testService)
    this.testService.getLocation().then(result => {
      this.locations = result;
    }).catch(error => {
      console.log('se futu');
    });
  }

  title = 'TripPlanner';
}
