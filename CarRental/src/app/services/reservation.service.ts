import { Injectable } from "@angular/core";
import { Reservation } from "../models/reservation";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from "rxjs/Operators";

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

  // getReservation(): Reservation {
  //   return this.client.get("https://localhost:44377/api/Reservation/1").pipe(
  //     map((res: Reservation()) => {
  //       return res;
  //     })
  //   );
  // }
}
