import { Component, OnInit } from "@angular/core";
import { DataPassService } from "../services/data-pass.service";
import { Reservation } from "../models/reservation";
import { ReservationService } from "../services/reservation.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-reservation-overview",
  templateUrl: "./reservation-overview.component.html",
  styleUrls: ["./reservation-overview.component.css"]
})
export class ReservationOverviewComponent implements OnInit {
  reservation: Reservation;
  updatedReservation: Reservation;

  timePeriod: number;
  totalCost: number;

  constructor(
    private dataPassService: DataPassService,
    private reservationService: ReservationService,
    private router: Router
  ) {}

  ngOnInit() {
    this.reservation = this.dataPassService.getReservation();
    console.log(this.reservation);
  }

  calculateTotalCost(reservation: Reservation): string {
    this.timePeriod =
      (new Date(reservation.returnDate).getTime() -
        new Date(reservation.pickUpDate).getTime()) /
      1000 /
      60 /
      60;
    console.log("Tyle godzin: " + this.timePeriod);
    console.log("Koszt: " + reservation.car.cost);
    if (reservation.clientAge > 25) {
      this.totalCost = 0.95 * reservation.car.cost * this.timePeriod;
    } else {
      this.totalCost = reservation.car.cost * this.timePeriod;
    }
    return this.totalCost.toFixed(2);
  }

  onDeleted() {
    this.reservationService
      .deleteReservation(this.reservation.id, this.reservation.clientLastName)
      .subscribe(res => {
        this.dataPassService.setReservation(res);
      });
  }

  onUpdated() {
    this.dataPassService.setUpdated(true);
    this.dataPassService.setUpdatedReservation(this.reservation);
    this.router.navigateByUrl("/overview/update");
  }
}