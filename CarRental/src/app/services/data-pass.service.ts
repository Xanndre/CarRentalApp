import { Injectable } from "@angular/core";
import { Reservation } from "../models/reservation";

@Injectable({
  providedIn: "root"
})
export class DataPassService {
  private reservation: Reservation;
  private updated: boolean;
  private updatedReservation: Reservation;

  constructor() {}

  getReservation(): Reservation {
    return this.reservation;
  }

  setReservation(reservation: Reservation) {
    this.reservation = reservation;
  }

  getUpdatedReservation(): Reservation {
    return this.updatedReservation;
  }

  setUpdatedReservation(updatedReservation: Reservation) {
    this.updatedReservation = updatedReservation;
  }

  getUpdated(): boolean {
    return this.updated;
  }

  setUpdated(updated: boolean) {
    this.updated = updated;
  }
}
