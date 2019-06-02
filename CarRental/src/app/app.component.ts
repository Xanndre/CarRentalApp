import { Component } from "@angular/core";
import { CarService } from "./services/car.service";
import { Car } from "./models/car";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "CarRental";
  cars: Car[];
  constructor(private carService: CarService) {
    this.carService.getAllCars().subscribe((res: Car[]) => {
      this.cars = res;
    });
  }
}
