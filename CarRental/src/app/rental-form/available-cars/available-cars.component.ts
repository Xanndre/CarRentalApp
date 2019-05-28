import { Component, OnInit, Input } from "@angular/core";
import { CarService } from "../../services/car.service";
import { Car } from "../../models/car";
import { Observable } from "rxjs";

@Component({
  selector: "app-available-cars",
  templateUrl: "./available-cars.component.html",
  styleUrls: ["./available-cars.component.css"]
})
export class AvailableCarsComponent implements OnInit {
  availableCars: Car[];

  @Input() dates: {
    pickUpDate: Date;
    returnDate: Date;
  };

  constructor(private carService: CarService) {
    //console.log(this.dates.pickUpDate.toString());
  }

  ngOnInit() {}

  ngOnChanges() {
    console.log("Wchodzi do ngOnChanges");
    this.carService
      .checkAvailableCars(this.dates.pickUpDate, this.dates.returnDate)
      .subscribe((res: Car[]) => {
        this.availableCars = res;
        console.log(this.availableCars);
      });
  }
}
