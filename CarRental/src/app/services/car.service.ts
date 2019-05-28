import { Injectable, Input, Output } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/Operators";
import { Observable } from "rxjs";
import { Car } from "../models/car";
import { EventEmitter } from "@angular/core";
@Injectable({
  providedIn: "root"
})
export class CarService {
  //checkedAvailableCars = new EventEmitter<Date[]>();

  constructor(private client: HttpClient) {}

  getAllCars(): Observable<Car[]> {
    return this.client.get("https://localhost:44377/api/Reservation/Cars").pipe(
      map((res: Car[]) => {
        return res;
      })
    );
  }

  checkAvailableCars(pickUpDate: Date, returnDate: Date): Observable<Car[]> {
    console.log(pickUpDate.toUTCString());
    console.log(returnDate.toUTCString());
    console.log(new Date().toUTCString());
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
}
