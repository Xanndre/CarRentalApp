import { Component, OnInit, Input } from "@angular/core";
import { CarService } from "../../services/car.service";
import { Car } from "../../models/car";
import { DataPassService } from "src/app/services/data-pass.service";
import { ReservationService } from "src/app/services/reservation.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-available-cars",
  templateUrl: "./available-cars.component.html",
  styleUrls: ["./available-cars.component.css"]
})
export class AvailableCarsComponent implements OnInit {
  availableCars: Car[];

  @Input() reservation: {
    clientAge: number;
    clientLastName: string;
    pickUpDate: Date;
    returnDate: Date;
    pickUpLocation: string;
    returnLocation: string;
    id: number;
    carId: number;
    car: Car;
  };

  constructor(
    private carService: CarService,
    private reservationService: ReservationService,
    private dataPassService: DataPassService,
    private router: Router
  ) {}

  ngOnInit() {}

  ngOnChanges() {
    this.carService
      .checkAvailableCars(
        this.reservation.pickUpDate,
        this.reservation.returnDate
      )
      .subscribe((res: Car[]) => {
        this.availableCars = res;
        console.log(this.availableCars);
      });
  }

  onClicked(carId: number) {
    this.reservation.carId = carId;
    this.reservationService
      .createReservation(this.reservation)
      .subscribe(res => {
        this.dataPassService.setReservation(res);
        this.router.navigateByUrl("/overview");
      });
  }
}
