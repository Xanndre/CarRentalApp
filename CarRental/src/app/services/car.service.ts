import { Injectable, Input, Output } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/Operators";
import { Observable } from "rxjs";
import { Car } from "../models/car";
@Injectable({
  providedIn: "root"
})
export class CarService {
  constructor(private client: HttpClient) {}

  getAllCars(): Observable<Car[]> {
    return this.client.get("https://localhost:44377/api/Reservation/Cars").pipe(
      map((res: Car[]) => {
        return res;
      })
    );
  }

  checkAvailableCars(pickUpDate: Date, returnDate: Date): Observable<Car[]> {
    const httpParams = new HttpParams()
      .set("pickUpDate", pickUpDate.toUTCString())
      .set("returnDate", returnDate.toUTCString());
    return this.client
      .get("https://localhost:44377/api/Reservation/AvailableCars", {
        params: httpParams
      })
      .pipe(
        map((res: Car[]) => {
          return res;
        })
      );
  }

  checkUpdatedAvailableCars(
    pickUpDate: Date,
    returnDate: Date,
    id: number
  ): Observable<Car[]> {
    const httpParams = new HttpParams()
      .set("pickUpDate", pickUpDate.toUTCString())
      .set("returnDate", returnDate.toUTCString())
      .set("id", id.toString());
    return this.client
      .get("https://localhost:44377/api/Reservation/AvailableCars", {
        params: httpParams
      })
      .pipe(
        map((res: Car[]) => {
          return res;
        })
      );
  }
}
