import { Injectable } from "@angular/core";
import { Reservation } from "../models/reservation";

@Injectable({
  providedIn: "root"
})
export class DataPassService {
  private reservation: Reservation;

  constructor() {}

  getReservation(): Reservation {
    return this.reservation;
  }

  setReservation(reservation: Reservation) {
    this.reservation = reservation;
  }
}
