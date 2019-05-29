import { Component, OnInit } from "@angular/core";
import { DataPassService } from "../services/data-pass.service";
import { Reservation } from "../models/reservation";

@Component({
  selector: "app-reservation-overview",
  templateUrl: "./reservation-overview.component.html",
  styleUrls: ["./reservation-overview.component.css"]
})
export class ReservationOverviewComponent implements OnInit {
  reservation: Reservation;
  constructor(private dataPassService: DataPassService) {}

  ngOnInit() {
    this.reservation = this.dataPassService.getReservation();
    console.log(this.reservation);
  }
}
