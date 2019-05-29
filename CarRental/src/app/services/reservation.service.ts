import { Injectable } from "@angular/core";
import { Reservation } from "../models/reservation";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from "rxjs/Operators";
import { DataPassService } from "./data-pass.service";

@Injectable({
  providedIn: "root"
})
export class ReservationService {
  constructor(private client: HttpClient) {}

  getAllReservations(): Observable<Reservation[]> {
    return this.client.get("https://localhost:44377/api/Reservation").pipe(
      map((res: Reservation[]) => {
        return res;
      })
    );
  }

  getReservation(id: number) {
    return this.client
      .get("https://localhost:44377/api/Reservation/" + id)
      .pipe(
        map((res: Reservation) => {
          return res;
        })
      );
  }

  createReservation(reservation: Reservation) {
    const options = {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    };
    return this.client.post<Reservation>(
      "https://localhost:44377/api/Reservation",
      reservation,
      options
    );
  }

  updateReservation(id: number, reservation: Reservation) {
    const options = {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    };
    return this.client.put(
      "https://localhost:44377/api/Reservation/" + id,
      reservation,
      options
    );
  }

  deleteReservation(id: number) {
    return this.client.delete("https://localhost:44377/api/Reservation/" + id);
  }
}
